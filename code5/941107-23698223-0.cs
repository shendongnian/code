    container.Register(
        // Register a config containing http://server.green/, set its name,
        // and register a named IXyzService depending on the config.
        Component.For<IWebApiClientConfiguration>().Named("greenConfig"),
        Component.For<IXyzService>().Named("greenService")
            .DependsOn(typeof (IWebApiClientConfiguration), "greenConfig"),
        
        // Register another config of the same interface containing http://server.red/,
        // and a named IXyzService that uses it.
        Component.For<IWebApiClientConfiguration>().Named("redConfig"),
        Component.For<IXyzService>().Named("redService")
            .DependsOn(typeof (IWebApiClientConfiguration), "redConfig"));
