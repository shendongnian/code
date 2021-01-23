    private Container ConfigureContainer()
    {
        Container container = new Container();
        container.RegisterOpenGeneric(
            typeof(ICachePolicy<>), 
            typeof(CachePolicy<>), 
            Lifestyle.Singleton);
        container.Register<A>();
        container.Register<B>();
        container.EnableLifetimeScoping();
        container.Verify();
        return container;
    }
