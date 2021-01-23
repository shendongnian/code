    IContainer container = new Container(x =>
        {
            x.ForRequestedType<IStayOnTillAppDies>()
                .TheDefaultIsConcreteType<StayOnTillAppDies>()
                .CacheBy(InstanceScope.Singleton);
            x.ForRequestedType<IDiesWhenRequestObjectDies>()
                .TheDefaultIsConcreteType<DiesWhenRequestObjectDies>()
                .CacheBy(InstanceScope.PerRequest);
        });
    container.Configure(x =>
        {
            x.SelectConstructor<StayOnTillAppDies>(() =>
                new StayOnTillAppDies(() => 
                    container.GetInstance<IDiesWhenRequestObjectDies>()));
        });
