    Fluently.Configure()
       .Database(
          MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString")))
          .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
          .CurrentSessionContext<T>()
          .BuildSessionFactory();
