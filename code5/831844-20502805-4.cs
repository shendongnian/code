        builder.RegisterType<ConnectionStringManager>().As<IConnectionStringManager>();
        builder.RegisterType<CustomerDataContext>()
            .As<ICustomerDataContext>()
            .As<IDbContext>()
            .InstancePerDependency();
