    public class MobileAuthService : IMobileAuthService
    {
        private const string stsEndpointAddress = @"https://<my_adfs_hostname>/adfs/services/trust/13/usernamemixed";
        private const string relyingPartyAddress =
            "https://<my_service_addr>/Auth.svc";
        public string AuthenticateUser(string username, string password)
        {
            var binding = new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential)
                {
                    ClientCredentialType = HttpClientCredentialType.None
                };
            var trustChannelFactory = new WSTrustChannelFactory(binding, new EndpointAddress(stsEndpointAddress))
                                            {
                                                TrustVersion = TrustVersion.WSTrust13
                                            };
            var channelCredentials = trustChannelFactory.Credentials;
            channelCredentials.UserName.UserName = username;
            channelCredentials.UserName.Password = password;
            channelCredentials.SupportInteractive = false;
            
            var tokenClient = (WSTrustChannel)trustChannelFactory.CreateChannel();
            var rst = new RequestSecurityToken(RequestTypes.Issue, KeyTypes.Bearer)
                {
                    AppliesTo = new EndpointReference(relyingPartyAddress),
                    ReplyTo = relyingPartyAddress,
                    TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0"
                };
            // to some token-related stuff (like transformations etc...)
        }
    }
