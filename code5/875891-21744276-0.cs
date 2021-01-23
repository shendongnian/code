    var service = new RealTimeOnlineClient();
    service.ClientCredentials.UserName.UserName = "xxxxx";
    service.ClientCredentials.UserName.Password = "yyyyy";
    
    var elements = service.Endpoint.Binding.CreateBindingElements();
    elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
    service.Endpoint.Binding = new CustomBinding(elements);
