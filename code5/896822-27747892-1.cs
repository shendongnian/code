    public class MvcDependencyResolver:System.Web.Mvc.IDependencyResolver
    {
        private readonly IDependencyResolver _resolver;
        private readonly System.Web.Mvc.IDependencyResolver _fallbackResolver;
        public MvcDependencyResolver(IDependencyResolver resolver, System.Web.Mvc.IDependencyResolver fallbackResolver)
        {
            this._resolver = resolver;
            this._fallbackResolver = fallbackResolver;
        }
        public object GetService(Type serviceType)
        {
            if ((this._resolver.IsRegistered(serviceType)) || (serviceType.IsClass))
            {
                try
                {
                    return this._resolver.GetService(serviceType);
                }
                catch (ResolutionFailedException)
                {
                }
            }
            return this._fallbackResolver.GetService(serviceType);
        }
