    public class NinjectFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
        {
            private readonly IKernel _kernel;
    
            public NinjectFilterProvider(IKernel kernel)
            {
                _kernel = kernel;
            }
    
            public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
            {
                var filters = base.GetFilters(configuration, actionDescriptor);
    
                foreach (var filter in filters)
                {
    
                    _kernel.Inject(filter.Instance);
                }
    
                return filters;
            }
        }
    
    public static class NinjectWebCommon 
        {
            private static readonly Bootstrapper bootstrapper = new Bootstrapper();
    
            /// <summary>
            /// Starts the application
            /// </summary>
            public static void Start() 
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                bootstrapper.Initialize(CreateKernel);
            }
            /// <summary>
            /// Stops the application.
            /// </summary>
            public static void Stop()
            {
                bootstrapper.ShutDown();
            }
            /// <summary>
            /// Creates the kernel that will manage your application.
            /// </summary>
            /// <returns>The created kernel.</returns>
            private static IKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
    
                //Support WebApi
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
    
                RegisterServices(kernel);
                return kernel;
            }
            /// <summary>
            /// Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            private static void RegisterServices(IKernel kernel)
            {
                //kernel.Bind<TCountingRepository>().To<CountingRepository>();
                //kernel.Bind<CountingContext>().To<CountinContext>();
                kernel.Bind<IAuthenticationService>().To<AlwaysAcceptAuthenticationService>();
    
                kernel.Bind<IFilterProvider>().To<NinjectFilterProvider>();
            }
        }
