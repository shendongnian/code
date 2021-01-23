    IUnityContainer container = new UnityContainer();
    container.RegisterType<IService, MyService>(new PerRequestLifetimeManager());
    container.RegisterType<IDbSession, DBSession>();
    
    IUnityContainer childContainer = container.CreateChildContainer();
    childContainer.RegisterType<IService, MyService>(new TransientLifetimeManager());
    
    IService parentService = container.Resolve<IService>();
    IService parentService2 = container.Resolve<IService>();
    IService childService = childContainer.Resolve<IService>();
