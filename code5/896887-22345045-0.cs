    public class MyRegistrationSoruce : IRegistrationSource
    {
        private readonly IServiceProvider serviceProvider;
    
        public MyRegistrationSoruce(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            // there are other registration exists in the container
            if (registrationAccessor(service).Any())
                return Enumerable.Empty<IComponentRegistration>();
                    
            var swt = service as IServiceWithType;
            if (swt == null)
                return Enumerable.Empty<IComponentRegistration>();
    
            // try to get an instance from the IServiceProvider
            var instance = serviceProvider.GetService(swt.ServiceType);
            if (instance == null)
                return Enumerable.Empty<IComponentRegistration>();
    
            // register the instance in the container
            return new[]
                {
                    RegistrationBuilder.ForDelegate(swt.ServiceType, 
                        (c, p) => instance)
                        .CreateRegistration()
                };
        }
        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
