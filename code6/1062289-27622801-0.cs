    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Flows;
    using Google.Apis.Auth.OAuth2.Requests;
    using Google.Apis.Util.Store;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MyOAuth2
    {
        //own implementation to append login_hint parameter to uri
    
        public class MyOAuth2WebAuthorizationBroker : GoogleWebAuthorizationBroker
        {
            public new static async Task<UserCredential> AuthorizeAsync(ClientSecrets clientSecrets,
                IEnumerable<string> scopes, string user, CancellationToken taskCancellationToken,
                IDataStore dataStore = null)
            {
                var initializer = new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                };
                return await AuthorizeAsyncCore(initializer, scopes, user, taskCancellationToken, dataStore)
                    .ConfigureAwait(false);
            }
    
            private static async Task<UserCredential> AuthorizeAsyncCore(
                GoogleAuthorizationCodeFlow.Initializer initializer, IEnumerable<string> scopes, string user,
                CancellationToken taskCancellationToken, IDataStore dataStore = null)
            {
                initializer.Scopes = scopes;
                initializer.DataStore = dataStore ?? new FileDataStore(Folder);
                var flow = new MyAuthorizationCodeFlow(initializer, user);
    
                // Create an authorization code installed app instance and authorize the user.
                return await new AuthorizationCodeInstalledApp(flow, new LocalServerCodeReceiver()).AuthorizeAsync
                    (user, taskCancellationToken).ConfigureAwait(false);
            }
        }
    
        public class MyAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
        {
            private readonly string userId;
    
            /// <summary>Constructs a new Google authorization code flow.</summary>
            public MyAuthorizationCodeFlow(Initializer initializer, string userId)
                : base(initializer)
            {
                this.userId = userId;
            }
    
            public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
            {
                return new GoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl))
                {
                    ClientId = ClientSecrets.ClientId,
                    Scope = string.Join(" ", Scopes),
                    //append user to url
                    LoginHint = userId,
                    RedirectUri = redirectUri
                };
            }
        }
    }
