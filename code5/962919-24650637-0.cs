		public static StandardKernel CreateKernel()
		{
			if (_kernel == null)
			{
				_kernel = new StandardKernel();
				_kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
				_kernel.Load(Assembly.GetExecutingAssembly(), Assembly.Load("Super.CompositionRoot"));
			}
			return _kernel;
		}
