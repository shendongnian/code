 		void InitializeMyWebService(bool useSSLSite)
		{
			BasicHttpBinding b = useSSLSite ? 
				new BasicHttpBinding(BasicHttpSecurityMode.Transport) : 
				new BasicHttpBinding();
			EndpointAddress e = useSSLSite ? 
				new EndpointAddress("https://www.example.com/svc/MyWebService.asmx") :
				new EndpointAddress("http://intranet_server/svc/MyWebService.asmx");
			myWebService = new MyWebServiceSoapClient(b, e);
		}
	}
