    public class NinjectDependencyResolverHelper : IDependencyScope
        {
            IResolutionRoot resolver;
            public NinjectDependencyResolverHelper(IResolutionRoot resolver)
            {
                this.resolver = resolver;
            }
            public object GetService(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has been disposed");
                return resolver.TryGet(serviceType);
            }
            public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has been disposed");
                return resolver.GetAll(serviceType);
            }
            public void Dispose()
            {
                var disposable = resolver as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
                resolver = null;
            }
        }
        public class NinjectDependencyResolver : NinjectDependencyResolverHelper, IDependencyResolver
        {
            IKernel kernel;
            public NinjectDependencyResolver(IKernel kernel)
                : base(kernel)
            {
                this.kernel = kernel;
            }
            public IDependencyScope BeginScope()
            {
                return new NinjectDependencyResolverHelper(kernel.BeginBlock());
            }
        }
