        Fluently.Configure()
        .Database(MySQLConfiguration.Standard
        .ConnectionString("xxx"))
        .Mappings(m => m.FluentMappings.AddFromAssembly(...))
         .ExposeConfiguration(c => c.DataBaseIntegration(prop =>
        {
            prop.BatchSize = 50;
            prop.Batcher<MySqlClientBatchingBatcherFactory>();
        }))
        .BuildSessionFactory();
