    var scopedLifestyle = new WebRequestLifestyle();
    container.Register<IMyService, MyService>();
    container.Register<ExternalServiceClient>(
        () => new ExternalServiceClient("WSHttpBinding_IExternalService"));
    container.RegisterInitializer<ExternalServiceClient>(client =>
    {
        scopedLifestyle.RegisterForDisposal(container, client);
    });
