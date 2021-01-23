    interface IProjectUnitOfWork : IUnitOfWork {}
    interface IProject2UnitOfWork : IUnitOfWork {}
    ....
    IUnityContainer oContainer = new UnityContainer()
    // ***** PROJECT *****
     .RegisterType<IProjectDBFactory, ProjectDBFactory>(new HttpContextLifetimeManager<IProjectDBFactory>())
     .RegisterType<IProjectUnitOfWork, ProjectUow>(new HttpContextLifetimeManager<IProjectUnitOfWork >())
     .RegisterType<IRepoPRJTABLE, RepoPRJTABLE>(new HttpContextLifetimeManager<IRepoPRJTABLE>())
     .RegisterType<IServiceRepository<PRJTABLE>, ServicePRJTABLE>(new HttpContextLifetimeManager<IServiceRepository<PRJTABLE>>())
    
     // ***** PROJECT2 *****
     .RegisterType<IProject2DBFactory, Project2WebDBFactory>(new HttpContextLifetimeManager<IProject2DBFactory>())
     .RegisterType<IProject2UnitOfWork, Project2Uow>(new HttpContextLifetimeManager<IProject2UnitOfWork >())
     .RegisterType<IRepoPRJ2TABLE, RepoPRJ2TABLE>(new HttpContextLifetimeManager<IRepoPRJ2TABLE>())
     .RegisterType<IServiceRepository<PRJ2TABLE>, ServicePRJ2TABLE>(new HttpContextLifetimeManager<IServiceRepository<PRJ2TABLE>>())
