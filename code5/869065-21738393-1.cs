     public static void Register(IUnityContainer container)
    {
        container
            .RegisterType<Database>(
            new ContainerControlledLifetimeManager(),
            new InjectionFactory(c => DatabaseFactory.CreateDatabase("Name")));
    }
