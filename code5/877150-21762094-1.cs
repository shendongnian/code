    public class AnotherContextModule : IModule
    {
        private readonly IUnityContainer container;
        public AnotherContextModule(IUnityContainer unityContainer)
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
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>("AnotherContext", new PerResolveLifetimeManager(), new InjectionConstructor(new AnotherContext()));
            
            // Customer Aggregate
            container.RegisterType<IReadOnlyEntityMapper<Customer, CustomerTable>, CustomerMapper>();
            container.RegisterType<ICustomerRepository, CustomerRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("AnotherContext"),
                    new ResolvedParameter<IReadOnlyEntityMapper<Customer, CustomerTable>>()));
            // Country Aggregate
            container.RegisterType<IReadOnlyEntityMapper<Country, CountryTable>, CountryMapper>();
            container.RegisterType<ICountryRepository, CountryRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("AnotherContext"),
                    new ResolvedParameter<IReadOnlyEntityMapper<Country, CountryTable>>()));
            // Province Aggregate
            container.RegisterType<IReadOnlyEntityMapper<Province, ProvinceTable>, ProvinceMapper>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>("AnotherContext"),
                    new ResolvedParameter<IReadOnlyEntityMapper<Province, ProvinceTable>>()));
        }
        private void SetupRegions()
        {
            // Register the views
        }
    }
