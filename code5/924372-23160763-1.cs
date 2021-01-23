    public class TenantDependencyResolver : IDependencyResolver
    {
        private static IUnityContainer _parentContainer;
        private static IDictionary<string, IUnityContainer> _childContainers = new Dictionary<string, IUnityContainer>();
        public TenantDependencyResolver()
        {
            var fakeTenentID = "localhost";
            var fakeTenentContainer = _parentContainer.CreateChildContainer();
            // register any specific fakeTenent Interfaces to classes here
            //Add the child container to the dictionary for use later
            _childContainers[fakeTenentID] = fakeTenentContainer;
        }
        private IUnityContainer GetContainer()
        {
            if (_childContainers.ContainsKey(HttpContext.Current.Items["TenantID"].ToString())
            {
                return _childContainers[tenantID];
            }
            return _parentContainer;
        }
        public object GetService(Type serviceType)
        {
            var container = GetContainer();
            return container.Resolve(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            var container = GetContainer();
            return container.ResolveAll(serviceType);
        }
    }
