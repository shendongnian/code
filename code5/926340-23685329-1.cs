    // I'm not completely sure why I need all these endpoints below, and since I provide an endpoint as such:
    //                 MessageReceivingEndpoint endpoint = new MessageReceivingEndpoint(uri, methods );
    // these don't seem like I need them.  But I need a ServiceProviderDescription to create a consumer, so...
    private ServiceProviderDescription GetServiceDescription()
    {
        return new ServiceProviderDescription
        {
            AccessTokenEndpoint = new MessageReceivingEndpoint("https://system.sandbox.netsuite.com/app/common/integration/ssoapplistener.nl", HttpDeliveryMethods.GetRequest),
            RequestTokenEndpoint = new MessageReceivingEndpoint("https://system.sandbox.netsuite.com/app/common/integration/ssoapplistener.nl", HttpDeliveryMethods.GetRequest),
            UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://system.sandbox.netsuite.com/app/common/integration/ssoapplistener.nl", HttpDeliveryMethods.GetRequest),
            ProtocolVersion = ProtocolVersion.V10a,
            TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new PlaintextSigningBindingElement() }
        };
    }
