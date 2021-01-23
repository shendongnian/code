	If by any reason you are not allowed to modify your `ConcreteSingleton`: This approach will wrap the singleton creation in a provider to efficiently inject the instance only for the first time it is created. It is important to note that the provider itself must be registered as a singleton.
		internal class ConcreteSingletonProvider : Provider<ISingleton>
		{
			public IKernel Kernel { get; set; }
			//Just a wrapper
			private readonly Lazy<ISingleton> _lazy = new Lazy<ISingleton>(() => ConcreteSingleton.Instance);
			public ConcreteSingletonProvider(IKernel kernel)
			{
				Kernel = kernel;
			}
			protected override ISingleton CreateInstance(IContext context)
			{
				if (_lazy.IsValueCreated == false)
				{
					Kernel.Inject(ConcreteSingleton.Instance);
				}
				return _lazy.Value;
			}
		}
	And your bindings should be like this:
		kernel.Bind<ISingleton>().ToProvider<ConcreteSingletonProvider>();
		kernel.Bind<ConcreteSingletonProvider>().ToSelf().InSingletonScope();
        
    This [gist][1] has a complete working sample for the above approach.
