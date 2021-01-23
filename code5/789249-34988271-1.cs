    sessionFactory = Fluently.Configure(normalConfig)
                      .Mappings(m =>
                          m.FluentMappings
                          .AddFromAssemblyOf<OrderMap>()
                          .Conventions.AddFromAssemblyOf<UnderscoreTableNameConvention>())
                          .ProxyFactoryFactory("NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate")
                      .BuildSessionFactory();
