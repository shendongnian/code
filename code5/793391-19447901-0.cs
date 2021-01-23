            [...]    
            
            serv = new WS_Generic.ServiceClient(ConfigureBinding(), ConfigureEndPointAddress());
            [...]
            private static EndpointAddress ConfigureEndPointAddress()
            {
                EndpointAddress endpointAddress = new EndpointAddress("xxx");
    
                return endpointAddress;
            }
    
            private static BasicHttpBinding ConfigureBinding()
            {
                BasicHttpBinding binding = new BasicHttpBinding();
    
                binding.AllowCookies = false;
                binding.BypassProxyOnLocal = false;
                binding.CloseTimeout = TimeSpan.Parse("00:01:00");
                binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                binding.MaxBufferPoolSize = 524288;
                binding.MaxBufferSize = 5242880;
                binding.MaxReceivedMessageSize = 5242880;
                binding.MessageEncoding = WSMessageEncoding.Text;
                binding.Name = "BasicHttpBinding_IService";
                binding.OpenTimeout = TimeSpan.Parse("00:01:00");
                binding.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                binding.SendTimeout = TimeSpan.Parse("00:01:00"); ;
                binding.TextEncoding = Encoding.UTF8;
                binding.TransferMode = TransferMode.Buffered;
                binding.UseDefaultWebProxy = true;
    
                return binding;
            }
