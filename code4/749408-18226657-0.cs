    public static IReadOnlyDictionary<string, IPersistenceConfigurer> DbConfigurations = 
        new ReadOnlyDictionary<string, IPersistenceConfigurer>(
            new Dictionary<string, IPersistenceConfigurer>
            {
                { "azure", MsSqlConfiguration.MsSql2008
                                        .ConnectionString("ConnectionString")
                                        .Dialect<MsSqlAzure2008Dialect>()
                                        .Driver<SqlAzureClientDriver>() },
                { "mssql", MsSqlConfiguration.MsSql2008
                                        .ConnectionString("ConnectionString")
                                        .Dialect<MsSql2008Dialect>() },
                { "sqlite", SQLiteConfiguration.Standard
                                                .InMemory() },
                // etc..
            });
