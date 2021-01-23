    public static void RegisterIoc(HttpConfiguration config)
            {
                var kernel = new StandardKernel(); // Ninject IoC
                kernel.Bind<IMyService>().To<MyService>();
    
                // Tell WebApi how to use our Ninject IoC
                config.DependencyResolver = new NinjectDependencyResolver(kernel);
            }
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
        {
            private IKernel kernel;
    
            public NinjectDependencyResolver(IKernel kernel)
                : base(kernel)
            {
                this.kernel = kernel;
            }
    
            public IDependencyScope BeginScope()
            {
                return new NinjectDependencyScope(kernel.BeginBlock());
            }
        }
    public class NinjectDependencyScope : IDependencyScope
        {
            private IResolutionRoot resolver;
    
            internal NinjectDependencyScope(IResolutionRoot resolver)
            {
                Contract.Assert(resolver != null);
    
                this.resolver = resolver;
            }
    
            public void Dispose()
            {
                var disposable = resolver as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
    
                resolver = null;
            }
    
            public object GetService(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has already been disposed");
    
                return resolver.TryGet(serviceType);
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                if (resolver == null)
                    throw new ObjectDisposedException("this", "This scope has already been disposed");
    
                return resolver.GetAll(serviceType);
            }
        }
