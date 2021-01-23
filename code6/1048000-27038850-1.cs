    public sealed class CompositionRoot :IDisposable, IHttpControllerActivator, IControllerFactory
    {
        // Singleton-scoped services are declared here...
        private readonly SingletonType_singletonInstance;
        public CompositionRoot()
        {
            // intitialise any application instance singletons
            _singletonInstance = new SingletonType()
        }
        
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            // Per-Request-scoped services are declared and initialized here
            if (controllerType == typeof(TestController))
            {
                return new TestController(_singletonInstance)
            }
        }
    }
