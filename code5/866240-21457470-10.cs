    container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager(), 
                                        new InjectionConstructor(new DbContext{Name = "UserDB"}));
    container.RegisterType<IUnitOfWork, UnitOfWork>("OrderDbContext", 
                                        new PerResolveLifetimeManager(),
                                        new InjectionConstructor(new DbContext { Name = "OrderDB" }));
    container.RegisterType<IUserRepository, UserRepository>();
    container.RegisterType<ITokenRepository, TokenRepository>();
    container.RegisterType<IOrderRepository, OrderRepository>(new InjectionConstructor(
                                        new ResolvedParameter<IUnitOfWork>("OrderDbContext"),                                                                
                                        typeof(IFooAdditionalDependency)));
    container.RegisterType<IFooAdditionalDependency, FooAdditionalDependency>();
