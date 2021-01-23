    public ICommand DisplayHomeView
    {
        get { return new ActionCommand(action => ViewModel = new HomeViewModel(), 
            canExecute => !IsViewModelOfType<HomeViewModel>()); }
    }
