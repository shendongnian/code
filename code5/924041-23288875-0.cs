    container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IDataContextAsync, SomeDBContext>(new PerRequestLifetimeManager())
                .RegisterType<IDataContext, SomeDBContext>(new PerRequestLifetimeManager())
                .RegisterType<ISomeService, SomeService>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Some>, Repository<Some>>(new PerRequestLifetimeManager());
