     private static ISessionFactory CreateSessionFactory()
            {
                var factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                            .ConnectionString(c =>
                                    c.FromConnectionStringWithKey("ECommerceConnectionString")))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMapping>())
                    .ExposeConfiguration(config =>
                    {
                        new SchemaUpdate(config).Execute(false, true);
                    })
                    .BuildSessionFactory();
                return factory;
            }
