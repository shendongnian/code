    container
        .RegisterType<IDataContextAsync, Zeus>("ZeusLive", new PerRequestLifetimeManager(), new InjectionConstructor("ZeusLive"))
        .RegisterType<IDataContextAsync, Zeus>(new PerRequestLifetimeManager(), new InjectionConstructor("Zeus"))
        .RegisterType<IUnitOfWorkAsync, UnitOfWork>()
        .RegisterType<IRepositoryAsync<cd_Job>, Repository<cd_Job>>();
