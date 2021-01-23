    using Google.Apis.Analytics.v3;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Flows;
    using Google.Apis.Auth.OAuth2.Requests;
    using Google.Apis.Auth.OAuth2.Web;
    using Google.Apis.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    
    namespace GoogleOauth2DemoWebApp
    {
        public class GoogleOauth
        {
            public AnalyticsService Handle(string _userId, string _connectionString, string _googleRedirectUri, string _applicationName, string[] _scopes)
            {
                try
                {
                    string UserId = _userId;//The user ID wil be for examlpe the users gmail address.
                    AnalyticsService service;
                    GoogleAuthorizationCodeFlow flow;
                    //use extended class to create google authorization code flow
                    flow = new ForceOfflineGoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                    {
                        DataStore = new DbDataStore(_connectionString),//DataStore class to save the token in a SQL database.
                        ClientSecrets = new ClientSecrets { ClientId = "XXX-YOUR CLIENTID-XXX", ClientSecret = "XXX-YOURCLIENTSECRET-XXX" },
                        Scopes = _scopes,
                    });
    
    
                    var uri = HttpContext.Current.Request.Url.ToString();
                    string redirecturi = _googleRedirectUri;//This is the redirect URL set in google developer console.
                    var code = HttpContext.Current.Request["code"];
                    if (code != null)
                    {
                        var token = flow.ExchangeCodeForTokenAsync(UserId, code,
                            uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;
    
                        var test = HttpContext.Current.Request["state"];
    
                        // Extract the right state.
                        var oauthState = AuthWebUtility.ExtracRedirectFromState(
                             flow.DataStore, UserId, HttpContext.Current.Request["state"]).Result;
                        HttpContext.Current.Response.Redirect(oauthState);
                    }
                    else
                    {
    
                        var result = new AuthorizationCodeWebApp(flow, redirecturi, uri).AuthorizeAsync(UserId,
                             CancellationToken.None).Result;
    
                        if (result.RedirectUri != null)
                        {
                            // Redirect the user to the authorization server.
                            HttpContext.Current.Response.Redirect(result.RedirectUri);
                        }
                        else
                        {
                            // The data store contains the user credential, so the user has been already authenticated.
                            service = new AnalyticsService(new BaseClientService.Initializer()
                            {
                                HttpClientInitializer = result.Credential,
                                ApplicationName = _applicationName
                            });
                            return service;
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
            }
    
            internal class ForceOfflineGoogleAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
            {
                public ForceOfflineGoogleAuthorizationCodeFlow(GoogleAuthorizationCodeFlow.Initializer initializer) : base(initializer) { }
    
                public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
                {
                    var ss = new Google.Apis.Auth.OAuth2.Requests.GoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl));
                    ss.AccessType = "offline";
                    ss.ApprovalPrompt = "force";
                    ss.ClientId = ClientSecrets.ClientId;
                    ss.Scope = string.Join(" ", Scopes);
                    ss.RedirectUri = redirectUri;
                    return ss;
                }
            };
        }
    }
