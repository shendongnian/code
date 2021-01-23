     IUnityContainer container = new UnityContainer();
     container.RegisterType<IService, MyService>(new TransientLifetimeManager());
     container.RegisterType<IDbSession, DBSession>(new PerRequestLifetimeManager());
    
     IUnityContainer childContainer = container.CreateChildContainer();
     childContainer.RegisterType<IDbSession, DBSession>(new TransientLifetimeManager());
    
     IService parentService = container.Resolve<IService>();
     IService parentService2 = container.Resolve<IService>();
     IService childService = childContainer.Resolve<IService>();
    IService childService2 = childContainer.Resolve<IService>();
