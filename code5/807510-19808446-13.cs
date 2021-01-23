    public Container ConfigureContainer()
    {
        Container container = new Container();
        container.RegisterOpenGeneric(
            typeof(ICachePolicy<>), 
            typeof(CachePolicy<>), 
            Lifestyle.Singleton);
        container.RegisterInitializer<CachePolicy<A>>(a =>
            a.AbsoluteExpiration = DateTime.Now.AddMinutes(1));
        container.RegisterManyForOpenGeneric(
            typeof(IQueryHandler<,>),
            typeof(IQueryHandler<,>).Assembly);
        container.RegisterDecorator(
            typeof(IQueryHandler<,>), 
            typeof(CachingQueryHandlerDecorator<,>));
        container.Verify();
        return container;
    }
