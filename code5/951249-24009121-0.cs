    Uri baseAddress = new Uri("http://localhost:8080/hello");
    
    using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
    {
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        host.Description.Behaviors.Add(smb);
        host.Open();
    
        Console.WriteLine("The service is ready at {0}", baseAddress);
        Console.WriteLine("Press <Enter> to stop the service.");
        Console.ReadLine();
        host.Close();
    }
