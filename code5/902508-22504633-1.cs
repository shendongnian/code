    var userControl = PreviousContentPresentationSite.Content as Catel.Windows.Controls.UserControl;
    if (userControl != null)
    {
    	userControl.CloseViewModelOnUnloaded = true;
    	var vm = userControl.ViewModel;
    	if (vm != null)
    	{
    		vm.CloseViewModel(true);
    	}
    }
    
    AbortTransition();
