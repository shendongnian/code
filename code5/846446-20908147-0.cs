    // during the ObjectFactory.Initialize
    x.SetAllProperties(set => set.OfType<ICacheProvider>());
    // something more...
    // this way the instance could be shared 
    x.For<ICacheProvider>()
        // as a singleton
        .Singleton()
        .Use<DefaultCacheProvider>();
