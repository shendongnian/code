    TransportSecurityBindingElement transportSecurity = new TransportSecurityBindingElement();
    // UsernameCredentials is a class implementing WS-UsernameToken authentication
    transportSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new UsernameTokenParameters());
    transportSecurity.AllowInsecureTransport = true;
    transportSecurity.IncludeTimestamp = false;
    TextMessageEncodingBindingElement messageEncoding = new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8);
    HttpClientCredentialType[] credentialTypes = new HttpClientCredentialType[3] { HttpClientCredentialType.None, HttpClientCredentialType.Basic, HttpClientCredentialType.Digest };
    ...
    foreach (HttpClientCredentialType credentialType in credentialTypes)
    {
        BasicHttpBinding httpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
        httpBinding.Security.Transport.ClientCredentialType = credentialType;
        BindingElementCollection elements = new BindingElementCollection(new BindingElement[1]{messageEncoding});
        foreach(BindingElement element in httpBinding.CreateBindingElements())
        {
            if (element is TextMessageEncodingBindingElement)
                continue;
            elements.Add(element);
        }
        CustomBinding customBinding = new CustomBinding(elements);
        DeviceClient deviceClient = new DeviceClient(customBinding, endPointAddress);
        if (credentialType == HttpClientCredentialType.Basic)
        {
             // Set all credentials, not sure from which one WCF actually takes the value
             deviceClient.ClientCredentials.UserName.UserName = pair[0];
             deviceClient.ClientCredentials.UserName.Password = pair[1];
        }
        else if (credentialType == HttpClientCredentialType.Digest)
        {
            deviceClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
            deviceClient.ClientCredentials.HttpDigest.ClientCredential.UserName = pair[0];
            deviceClient.ClientCredentials.HttpDigest.ClientCredential.Password = pair[1];
        }
    }
