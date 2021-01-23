    public MainViewModel()
    {
        Messenger.Default.Register<PageNavigationMessage>(this, SetPageViewModel);
    }
    private void SetPageViewModel(IPageViewmodel selectedVm)
    {
    
        switch (selectedVm.CurrentViewModel.Name)
        {
           case "Page1":
                 CurrentPageViewModel = PageViewModels[0];
                 break;
           case "Page2":
                 CurrentPageViewModel = PageViewModels[1];
                 break;
        }    
    }
