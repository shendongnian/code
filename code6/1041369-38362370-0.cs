    class MyViewModel1 : IMyViewModel
	{
		public MyViewModel1(IPageNavigationService navigator, IDestinationViewModel destination)
		{
			GoToPageCommand = new RelayCommand(() => 
                    navigator.NavigateToDestinationPage(destination));
		}
		public ICommand GoToPageCommand { get; }
	}
