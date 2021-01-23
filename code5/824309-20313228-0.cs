    var configure = new Configuration().Configure();
    configure.DataBaseIntegration(x =>
        {
            x.Dialect<MySQL5Dialect>();
            x.ConnectionStringName = "db";
            x.BatchSize = 50;
            x.Batcher<MySqlClientBatchingBatcherFactory>();
    
        })
        .Cache(x => x.UseQueryCache = true)
        .CurrentSessionContext<WebSessionContext>();
