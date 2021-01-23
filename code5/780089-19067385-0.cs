    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    
    namespace Namespace.Helpers
    {
        public class MyFacebookClient : DotNetOpenAuth.AspNet.Clients.OAuth2Client
        {
            private const string AuthorizationEP = "https://www.facebook.com/dialog/oauth";
            private const string TokenEP = "https://graph.facebook.com/oauth/access_token";
            private readonly string _appId;
            private readonly string _appSecret;
    
            public MyFacebookClient(string appId, string appSecret)
                : base("facebook")
            {
                this._appId = appId;
                this._appSecret = appSecret;
            }
    
    
            protected override Uri GetServiceLoginUrl(Uri returnUrl)
            {
                return new Uri(
                            AuthorizationEP
                            + "?client_id=" + this._appId
                            + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                            + "&scope=email,user_about_me"
                            + "&display=page"
                            + "&auth_type=reauthenticate"
                        );
            }
    
            protected override IDictionary<string, string> GetUserData(string accessToken)
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(
                    "https://graph.facebook.com/me?access_token=" + accessToken
                );
                dynamic data = Json.Decode(content);
                return new Dictionary<string, string> {
                    {
                        "id",
                        data.id
                    },
                    {
                        "name",
                        data.name
                    },
                    {
                        "photo",
                        "https://graph.facebook.com/" + data.id + "/picture"
                    },
                    {
                        "email",
                        data.email
                    }
                };
            }
    
            protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(
                    TokenEP
                    + "?client_id=" + this._appId
                    + "&client_secret=" + this._appSecret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                    + "&code=" + authorizationCode
                );
    
                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(content);
                if (nameValueCollection != null)
                {
                    string result = nameValueCollection["access_token"];
                    return result;
                }
                return null;
            }
        }
    }
