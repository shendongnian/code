    container.RegisterType<IUserRepository>( 
        new InjectionFactory(
           c => new UserEntityRepository( 
             c.Resolve<IDataContextFactory<SampleDataContext>> ), 
        new ContainerControlledLifetimeManager() );
