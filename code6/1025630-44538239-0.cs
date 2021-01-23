    public class NinjectDepsolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDepsolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public void Dispose()
        {
            _kernel = null;
        }
        public object GetService(Type serviceType) => _kernel.TryGet(serviceType);
        public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType).ToArray();
        public IDependencyScope BeginScope() => new DepScope(this);
        class DepScope : IDependencyScope
        {
            private NinjectDepsolver _depsolver;
            public DepScope(NinjectDepsolver depsolver)
            {
                _depsolver = depsolver;
            }
            public void Dispose()
            {
                _depsolver = null;
            }
            public object GetService(Type serviceType) => _depsolver.GetService(serviceType);
            public IEnumerable<object> GetServices(Type serviceType) => _depsolver.GetServices(serviceType);
        }
    }
