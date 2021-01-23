    ServiceMetadataBehavior serviceMetadataBehavior = 
        host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    if (serviceMetadataBehavior == null)
    {
        serviceMetadataBehavior = new ServiceMetadataBehavior();
        host.Description.Behaviors.Add(serviceMetadataBehavior);
    }
    host.AddServiceEndpoint(
        typeof(IMetadataExchange), 
        MetadataExchangeBindings.CreateMexNamedPipeBinding(), 
        "net.pipe://localhost/PipeReverse/mex"
    );
