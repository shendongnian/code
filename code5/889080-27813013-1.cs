    public class AppFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new CustomAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "...",
                    ClientSecret = "..."
                },
                Scopes = new String[] { AnalyticsService.Scope.AnalyticsReadonly },
                DataStore = new EFDataStore(),
            });
        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
        public override String GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            return String.Format("user-{0}", WebSecurity.GetUserId(controller.User.Identity.Name));
        }
    }
