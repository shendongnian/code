        var customBinding = new CustomBinding();
        customBinding.Elements.Add(new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.Soap12, });
        customBinding.Elements.Add(new HttpTransportBindingElement { MaxReceivedMessageSize = 20000000, });
        var endpointAddres = new EndpointAddress(listeningUri);
        var client = new Client(customBinding, endpointAddres);
        // add my own IEndpointBehavior
        client.ChannelFactory.Endpoint.Behaviors.Add(new CustomBehavior());
        client.SomeMethod();
