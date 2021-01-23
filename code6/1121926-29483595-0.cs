    string endpointUri = string.Format("https://{0}/adfs/services/trust/13/usernamemixed", _serverName);
    var factory = new Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory(
                  new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                  new EndpointAddress(endpointUri));
    factory.TrustVersion = TrustVersion.WSTrust13;
    if (factory.Credentials != null)
    {
        factory.Credentials.UserName.UserName = "UserName";
        factory.Credentials.UserName.Password = "password";
    }
    var rst = new RequestSecurityToken
    {
        RequestType = WSTrust13Constants.RequestTypes.Issue,
        AppliesTo = new EndpointAddress(_relyingPartyUri),
        KeyType = WSTrust13Constants.KeyTypes.Bearer,
    };
    var channel = factory.CreateChannel();
    SecurityToken token = channel.Issue(rst);
    return token;
