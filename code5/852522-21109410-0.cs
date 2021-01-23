    ObjectFactory.Initialize(config => {
        config.For<ISessionFactory>().Singleton().Use(() => 
          Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c =>
            c.FromConnectionStringWithKey("DefaultConnection")))
            .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>())
            .BuildConfiguration()
            .BuildSessionFactory()));
        config.For<ISession>().HttpContextScoped()
          .Use(c => c.GetInstance<ISessionFactory>().OpenSession());
    });
