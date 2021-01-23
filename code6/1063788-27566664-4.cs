    var f1 = Lifestyle.Singleton.CreateRegistration<IDbConnectionFactory>(
        () => new OrmLiteConnectionFactory(
                conn1,
                ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider.Instance), 
            container);
    var f2 = Lifestyle.Singleton.CreateRegistration<IDbConnectionFactory>(
        () => new OrmLiteConnectionFactory(
                conn2,
                ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider.Instance), 
            container);
    container.RegisterConditional(typeof(IDbConnectionFactory), f1, InjectedInto<SqlOrderRepo>);
    container.RegisterConditional(typeof(IDbConnectionFactory), f2, InjectedInto<SqlUserRepo>);
    // Helper method.
    static bool InjectedInto<T>(PredicateContext c) =>
        c.Consumer.ImplementationType == typeof(T);
