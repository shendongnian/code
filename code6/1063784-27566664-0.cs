    container.RegisterWithContext<OrmLiteConnectionFactory>(c =>
    {
        if (c.ImplementationType == typeof(SqlOrderRepository))
            return connectionFactory1;
        if (c.ImplementationType == typeof(SqlUserRepository))
            return connectionFactory2;
        throw new InvalidOperationException("Unbound type: " + c.ImplementationType);
    });
