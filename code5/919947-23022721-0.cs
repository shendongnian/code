     WebServiceHost serviceHost = new WebServiceHost(typeof(ProductServiceTest), new  Uri("http://localhost:9000/"));
            WebHttpBinding webHttpBinding = new WebHttpBinding();
            webHttpBinding.MaxReceivedMessageSize = 65536 * 2;
            webHttpBinding.MaxBufferPoolSize=2147483647L; 
            webHttpBinding.MaxBufferSize=2147483647;
            webHttpBinding.MaxReceivedMessageSize = 2147483647L;
            serviceHost.AddServiceEndpoint(typeof(IProductServiceTest), webHttpBinding, "");
            // Check to see if the service host already has a ServiceMetadataBehavior
            ServiceMetadataBehavior smb = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            // If not, add one
            if (smb == null)
                smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);
            serviceHost.Open();
            Console.WriteLine("Press <ENTER> to terminate the service host");
            Console.ReadLine();
            serviceHost.Close();
