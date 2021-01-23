    Component.For<Task<ISessionFactory>>().UsingFactoryMethod(
        k => Task.Factory.StartNew(
            () =>
                Fluently.Configure()
                    .Database(
                        () => OracleClientConfiguration.Oracle10.ConnectionString(
                            c => c.Is(k.Resolve<ISifarmaConnectionString>().Value))
    #if DEBUG
                        .ShowSql().FormatSql()
    #endif
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ISifarmaUnitOfWork>())
    #if DEBUG
                    .ExposeConfiguration(c => c.SetInterceptor(new SqlStatementInterceptor()))
    #endif
                    .BuildSessionFactory());
        }).LifestyleSingleton(),
