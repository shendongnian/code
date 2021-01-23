	public class UnityJobActivator : JobActivator
	{
		[ThreadStatic]
		private static IUnityContainer childContainer;
		public UnityJobActivator(IUnityContainer container)
		{
			// Register dependencies
			container.RegisterType<MyService>(new HierarchicalLifetimeManager());
			Container = container;
		}
		public IUnityContainer Container { get; set; }
		public override object ActivateJob(Type jobType)
		{
			return childContainer.Resolve(jobType);
		}
		public void CreateChildContainer()
		{
			childContainer = Container.CreateChildContainer();
		}
		public void DisposeChildContainer()
		{
			childContainer.Dispose();
			childContainer = null;
		}
	}
