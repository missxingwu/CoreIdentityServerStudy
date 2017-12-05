using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Test;

namespace QuickstartIdentityServer
{
    /// <summary>
    /// http://www.cnblogs.com/stulzq/tag/IdentityServer4/
    /// </summary>
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    //1.0 没有交互性用户，使用客户端证书 实现认证。
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
	                // 用于认证的密码
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
	                // 客户端有权访问的范围（Scopes）
                    AllowedScopes = { "api1" }
                },
                 new Client
                 { 
                     //2.0 使用密码授权 实现认证。
                     ClientId = "ro.client",
                     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                     ClientSecrets =
                     {
                         new Secret("secret".Sha256())
                     },
                     AllowedScopes = { "api1" }
                 }
            };
        }


        /// <summary>
        /// 测试密码登录用户账号
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "alice"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "bob"
                }
            };
        }
    }
}