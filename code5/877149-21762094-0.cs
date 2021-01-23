    public class FirstContextModule : IModule
    {
        private readonly IUnityContainer container;
        public FirstContextModule(IUnityContainer unityContainer)
        {
            this.container = unityContainer;
        }
        public void Initialize()
        {
            this.SetupContainer();
            this.SetupRegions();
        }
        private void SetupContainer()
        {
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>("FirstContext", new PerResolveLifetimeManager(), new InjectionConstructor(new FirstContext()));
            
            // User Aggregate
            container.RegisterType<IEntityMapper<User, UserTable>, UserMapper>();
            container.RegisterType<IUserRepository, UserRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("FirstContext"),
                    new ResolvedParameter<IEntityMapper<User, UserTable>>()));
    
            // Token Aggregate
            container.RegisterType<IEntityMapper<Token, TokenTable>, TokenMapper>();
            container.RegisterType<ITokenRepository, TokenRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("FirstContext"),
                    new ResolvedParameter<IEntityMapper<Token, TokenTable>>()));
    
            // Payment Aggregate
            container.RegisterType<IReadOnlyEntityMapper<Payment, PaymentTable>, PaymentFactory>();
            container.RegisterType<IPaymentRepository, PaymentRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("FirstContext"),
                    new ResolvedParameter<IReadOnlyEntityMapper<Payment, PaymentTable>>()));
        }
        private void SetupRegions()
        {
            // Register the views
        }
    }
