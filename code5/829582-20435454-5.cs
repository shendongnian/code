    if (!result.Errors.HasErrors)
    {
        Type type = result.CompiledAssembly.GetType("DynamicService");
        var instance = Activator.CreateInstance(type);
        Uri baseAddress = new Uri("http://localhost:80/hello");
        using (ServiceHost host = new ServiceHost(type, baseAddress))
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);
            host.Open();
            Console.WriteLine("The service is ready at {0}", baseAddress);
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();
            // Close the ServiceHost.
            host.Close();
        }
    }
