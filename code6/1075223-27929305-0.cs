	public static class NinjectWebCommon 
	{
		private static readonly Bootstrapper Bootstrapper = new Bootstrapper();
		public static void Start() 
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			Bootstrapper.Initialize(CreateKernel);
		}
		
		public static void Stop()
		{
			Bootstrapper.ShutDown();
		}
		
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
			
			
			// Needed to add this binding.
			kernel.Bind<IWraper>().To<Wraper>().InRequestScope();
			
			
			RegisterServices(kernel);
			GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
			
			return kernel;
		}
	}
