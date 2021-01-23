    resp.Clear();  // cleared the response
    var fa = FederatedAuthentication.WSFederationAuthenticationModule;
    var signInRequestMessage = new SignInRequestMessage(new Uri(fa.Issuer), fa.Realm);
    var signInURI = signInRequestMessage.WriteQueryString();
    resp.Write(signInURI);
