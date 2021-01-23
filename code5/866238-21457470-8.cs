        container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(
                         //Let's assume the Uow was registered as a named registration                   
                         new ResolvedParameter<IUnitOfWork>("UserUow"),
                         //provide information about additional parameters in the constructor
                         new ResolvedParameter<IEntityFactory<User,UserTbl>>()));
        container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(
                         //Let's assume the Uow was registered as a named registration                   
                         new ResolvedParameter<IUnitOfWork>("UserUow"),
                         //provide information about additional parameters in the constructor
                         typeof(<IEntityFactory<User,UserTbl>>)));
