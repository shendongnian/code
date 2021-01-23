    class Bootstrapper
	{
		private Container _container = new Container();
		public Bootstrapper(Frame frame)
		{
			_container.RegisterSingleton(frame);
			_container.RegisterSingleton<IPageNavigationService, PageNavigationService>();
			_container.Register<IMyViewModel, MyViewModel1>();
			_container.Register<IDestinationViewModel, IDestinationViewModel>();
    #if DEBUG
			_container.Verify();
    #endif
		}
		public IMyViewModel GetMainScreenViewModel()
		{
			return _container.GetInstance<IMyViewModel>();
		}
	}
    
