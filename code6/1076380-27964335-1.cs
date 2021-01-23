    public static class TestFactory
    {
        public static DatabaseFactory DbFactory { get; set; }
    
        public static void Setup()
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new OurMappings());
            //or individual mappings
            //var fluentConfig = FluentMappingConfiguration.Configure(new UserMapping(), ....);
    
            DbFactory = DatabaseFactory.Config(x =>
            {
                // Load the connection string here or just use a constant in code...
                x.UsingDatabase(() => new Database("connString");
                x.WithFluentConfig(fluentConfig);
                x.WithMapper(new Mapper());
            });
        }
    }
