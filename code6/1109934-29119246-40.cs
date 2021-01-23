    // The bootstrapper sets up the container/engine etc
    public class Bootstrapper
    {
        // Castle Windsor Container
        private readonly IWindsorContainer _container;
 
        // Service for writing to logs
        private readonly ILogService _logService;
        // Bootstrap the service
        public Bootstrapper()
        {
            _container = new WindsorContainer();
 
            // Some Castle Windsor features:
            // Add a subresolver for collections, we want all queues to be resolved generically
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            // Add the typed factory facility and wcf facility
            _container.AddFacility<TypedFactoryFacility>();
            _container.AddFacility<WcfFacility>();
            // Winsor uses Installers for registering components
            // Install the core dependencies
            _container.Install(FromAssembly.This());
            // Windsor supports plugins by looking in directories for assemblies which is a nice feature - I use that here:
            // Install any plugins from the plugins directory
            _container.Install(FromAssembly.InDirectory(new AssemblyFilter("plugins", "*.dll")));
            _logService = _container.Resolve<ILogService>();
        }
        /// <summary>
        /// Gets the engine instance after initialisation or returns null if initialisation failed
        /// </summary>
        /// <returns>The active engine instance</returns>
        public IIntegrationEngine GetEngine()
        {
            try
            {
                return _container.Resolve<IIntegrationEngine>();
            }
            catch (Exception ex)
            {
                _logService.Fatal(new Exception("The engine failed to initialise", ex));
            }
            return null;
        }
        // Get an instance of the container (for debugging)
        public IWindsorContainer GetContainer()
        {
            return _container;
        }
    }
