              ISessionFactory factory = Fluently.Configure()
                                     .Database(
                           IfxSQLIConfiguration
                          .Informix1000
                          .ConnectionString("conectionString")
                          .Driver<OleDbDriver>()
                          .Dialect<InformixDialect1000>()
                            //.ConnectionString(c => c.FromConnectionStringWithKey(databaseKey))
                          .ShowSql())
                          .Mappings(x => x.FluentMappings.AddFromAssemblyOf<TvLoginMapping>()
                          .Conventions.AddFromAssemblyOf<CustomTypeConvention>()
                          )
                          .BuildSessionFactory();
                        factories.Add(databaseKey, factory);
                    }
