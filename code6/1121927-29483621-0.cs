    public class UserNameWSTrustBinding : WS2007HttpBinding
    {
        public UserNameWSTrustBinding()
        {
            Security.Mode = SecurityMode.TransportWithMessageCredential;
            Security.Message.EstablishSecurityContext = false;
            Security.Message.ClientCredentialType = MessageCredentialType.UserName;
        }
    }
    string endpointUri = string.Format("https://{0}/adfs/services/trust/13/usernamemixed", _serverName);
    var factory = new WSTrustChannelFactory(new UserNameWSTrustBinding(), endpointUri)
        {
            TrustVersion = TrustVersion.WSTrust13
        };
    factory.Credentials.UserName.UserName = "UserName";
    factory.Credentials.UserName.Password = "password";
    var rst = new RequestSecurityToken
    {
        RequestType = RequestTypes.Issue,
        AppliesTo = new EndpointReference(_relyingPartyUri),
        KeyType = KeyTypes.Symmetric
    };
    var channel = factory.CreateChannel();
    
    return channel.Issue(rst);
