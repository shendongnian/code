	public class Module : NinjectModule
	{
		public override void Load()
		{
			Bind<MessageChannel, MessageChannelViewModel>().To<MessageChannelViewModel>().InSingletonScope();
			
			Bind<Operation>().To<DefaultOperation>();
			Bind<OperationFactory>().ToFactory();
			
			var uniqueName = "UNIQUE";
			Bind<IsolatedViewModel>()
				.To<DefaultIsolatedViewModel>()
				.Named(uniqueName)
				.DefinesNamedScope(uniqueName);
			
			Bind<MessageChannel, MessageChannelViewModel>().To<MessageChannelViewModel>()
				.WhenAnyAncestorNamed(uniqueName)
				.InNamedScope(uniqueName);
				
			Bind<IsolatedViewModelFactory>().ToFactory();
		}
	}
