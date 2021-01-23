    class PageNavigationService : IPageNavigationService
	{
		private readonly Frame _navigationFrame;
		public PageNavigationService(Frame navigationFrame)
		{
			_navigationFrame = navigationFrame;
		}
		void Navigate(Type type, object dataContext)
		{
			_navigationFrame.Navigate(type);
			_navigationFrame.DataContext = dataContext;
		}
		public void NavigateToDestinationPage(IDestinationViewModel dataContext)
		{
			// Page2 is the corresponding view of the destination view model
			Navigate(typeof(Page2), dataContext);
		}
	}
