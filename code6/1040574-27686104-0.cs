     public class OfflinAccesseGoogleAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
        {
            public OfflinAccessGoogleAuthorizationCodeFlow(GoogleAuthorizationCodeFlow.Initializer initializer) : base(initializer) { }
    
            public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
            {
                return new GoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl))
                {
                    ClientId = ClientSecrets.ClientId,
                    Scope = string.Join(" ", Scopes),
                    RedirectUri = redirectUri,
                    AccessType = "offline",
                    ApprovalPrompt = "force"
                };
            }
        };
