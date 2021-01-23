    public class LogoutHandler
    {
        public string Signout()
        {
            // Load Identity Configuration
            FederationConfiguration config = FederatedAuthentication.FederationConfiguration;
            // Get wtrealm from WsFederationConfiguation Section
            string wtrealm = config.WsFederationConfiguration.Realm;
            string wreply;
            wreply = wtrealm;
            // Read the ACS Ws-Federation endpoint from web.Config
            string wsFederationEndpoint = ConfigurationManager.AppSettings["ida:Issuer"];
            SignOutRequestMessage signoutRequestMessage = new SignOutRequestMessage(new Uri(wsFederationEndpoint));
            signoutRequestMessage.Parameters.Add("wreply", wreply);
            signoutRequestMessage.Parameters.Add("wtrealm", wtrealm);
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
            return signoutRequestMessage.WriteQueryString();            
        }
    }
