    // Create container and register types
    IUnityContainer myContainer = new UnityContainer();
    myContainer.RegisterType<IMyService, DataService>("Data");
    myContainer.RegisterType<IMyService, LoggingService>("Logging");
    
    // Retrieve an instance of each type
    IMyService myDataService = myContainer.Resolve<IMyService>("Data");
    IMyService myLoggingService = myContainer.Resolve<IMyService>("Logging");
