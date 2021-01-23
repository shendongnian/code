     //define binding
                BasicHttpBinding myBinding = new BasicHttpBinding();
                myBinding.Name = "basicHttp_HI_SSLBinding";
                myBinding.OpenTimeout = TimeSpan.FromMinutes(1);
                myBinding.CloseTimeout = TimeSpan.FromMinutes(1);
                myBinding.SendTimeout = TimeSpan.FromMinutes(1);
                myBinding.ReceiveTimeout = TimeSpan.FromMinutes(10);
                myBinding.BypassProxyOnLocal = false;
                myBinding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;
                myBinding.MaxBufferPoolSize = 2147483647;
                myBinding.MaxReceivedMessageSize = 2147483647;
                myBinding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                myBinding.TextEncoding = Encoding.UTF8;
                myBinding.UseDefaultWebProxy = true;
                myBinding.AllowCookies = false;
                myBinding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                myBinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Certificate;
                myBinding.Security.Transport.ProxyCredentialType = System.ServiceModel.HttpProxyCredentialType.None;
                myBinding.Security.Transport.Realm = "";
    
                //define endpoint url              
                EndpointAddress myEndpoint = new EndpointAddress("https://10.50.1.85:1345/HI/HIService.svc/ws");
    
                //Use channle factory to autogenerate proxy class 
                ChannelFactory<HILib.HIService.IHIService> myChannelFactory = new ChannelFactory<HILib.HIService.IHIService>(myBinding, myEndpoint);
                HILib.HIService.IHIService HIService = myChannelFactory.CreateChannel();
    
                //and call it
                var result = HIService.SomeMethodcall();
    
                ((IClientChannel)HIService).Close();
                myChannelFactory.Close();
