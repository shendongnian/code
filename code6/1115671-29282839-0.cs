    var endpoint = new EndpointAddress(
    	new Uri(ConfigurationManager.AppSettings["same url as above"]),
    	EndpointIdentity.CreateUpnIdentity("user@domain.com.br"),
    	(System.ServiceModel.Channels.AddressHeaderCollection)null);
    
    var client3 = new ServiceReference1.IntegracaoClient(
    	new WSHttpBinding(),
    	endpoint);
