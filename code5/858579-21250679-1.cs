    // Register your dependency with a key, for example a bool flag
    builder.RegisterType<TypeA>().Keyed<IService>(true);
    builder.RegisterType<TypeB>().Keyed<IService>(false);
    // Your service could look like:
    public class MyWcfService
    {
        private readonly IIndex<bool, IService> _services;
        
        // Inject IIndex<Key,Value> into the constructor, Autofac will handle it automatically
        public MyWcfService(IIndex<bool, IService> services)
        {
            _services = services;
        }
        public virtual void Operation(MyRequest request)
        {
            // Get the service that you need by the key
            var service = _services[request.MyBool];
        }
    }
  
