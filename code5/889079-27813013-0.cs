    public class CustomAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
    {
        public CustomAuthorizationCodeFlow(GoogleAuthorizationCodeFlow.Initializer initializer) : base(initializer) { }
        public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(String redirectUri)
        {
            return new GoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl))
            {
                ClientId = ClientSecrets.ClientId,
                Scope = string.Join(" ", Scopes),
                RedirectUri = redirectUri,
                AccessType = "online",
                ApprovalPrompt = "auto"
            };
        }
    }
