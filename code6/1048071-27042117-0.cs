    // binding
    var binding = new CustomBinding();
    binding.Elements.Clear();
    binding.Elements.Add(new TextMessageEncodingBindingElement{MessageVersion = MessageVersion.Soap12});
    binding.Elements.Add(new HttpTransportBindingElement{MaxReceivedMessageSize = 20000000,});
    // endpoint
    var endpoint = new EndpointAddress(new Uri(listeningUri), new MySecurityHeader())
    var client = new Client(binding, endpoint);
    client.SomeMethod();
