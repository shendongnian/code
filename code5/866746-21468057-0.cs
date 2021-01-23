    interface FluentStart
    {
        AddService( service );
        AddService( service, Action<FluentServiceConfiguration> config );
    }
    // Normal service registration
    .AddService(myService)
    // Service registration with additional parameters
    .AddService(myOtherService, x => x.WithParameter(ServiceParam.Timeout, 100))
    .AddService(myThirdService)
