    var scopedLifestyle = new WebRequestLifestyle();
    container.Register<IMyService, MyService>();
    container.Register<ExternalServiceClient>(
        () => new ExternalServiceClient("WSHttpBinding_IExternalService"));
    container.RegisterInitializer<ExternalServiceClient>(client =>
    {
        scopedLifestyle.WhenScopeEnds(container, () =>
        {
            try
            {
                client.Dispose();
            }
            catch 
            {
                // According to Marc Gravell we need to have a catch all here. 
            }
        });
    });
