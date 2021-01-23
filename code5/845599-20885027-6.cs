    public class AppBootstrapper : Bootstrapper<MainViewModel>
	{
		private Container container;
		/// <summary>
		/// Override to configure the framework and setup your IoC container.
		/// </summary>
		protected override void Configure()
		{
			container = new Container();
			container.Register<IWindowManager, WindowManager>();
			container.Register<IEventAggregator, EventAggregator>();
			var viewModels =
				Assembly.GetExecutingAssembly()
					.DefinedTypes.Where(x => x.GetInterface(typeof(IMainScreenTabItem).Name) != null && !x.IsAbstract && x.IsClass);
			container.RegisterAll(typeof(IMainScreenTabItem), viewModels);
			container.Verify();
		}
		/// <summary>
		/// Override this to provide an IoC specific implementation.
		/// </summary>
		/// <param name="service">The service to locate.</param><param name="key">The key to locate.</param>
		/// <returns>
		/// The located service.
		/// </returns>
		protected override object GetInstance(Type service, string key)
		{
			if (service == null)
			{
				var typeName = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.Name.Contains(key)).Select(x => x.AssemblyQualifiedName).Single();
				service = Type.GetType(typeName);
			}
			return container.GetInstance(service);
		}
		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}
		protected override void BuildUp(object instance)
		{
			container.InjectProperties(instance);
		}
	}
