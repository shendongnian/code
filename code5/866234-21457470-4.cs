    container.RegisterType<IUserRepository, UserRepository>();
    container.RegisterType<ITokenRepository, TokenRepository>();
    container.RegisterType<IOrderRepository, OrderRepository>(new InjectionConstructor(
                                           new ResolvedParameter<IUnitOfWork>("OrderUow"),
                                           //additional dependencies in the OrderRepository constructor, resolved using default Unity registrations
                                           new ResolvedParameter<IEntityFactory<Order,OrderTbl>>()));
