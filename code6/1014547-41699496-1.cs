    private readonly IRegionManager _regionManager;
    public ICommand GoBackCommand { get; set; }
    public ClassName(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        GoBackCommand = new DelegateCommand(GoBack, CanGoBack);
    }
    private bool CanGoBack()
    {  return _regionManager.Regions[RegionNames.MainRegion].NavigationService.Journal.CanGoBack;/*or CanGoForward */}
    private void GoBack()
    { _regionManager.Regions[RegionNames.MainRegion].NavigationService.Journal.GoBack();/*GoForward()*/ }
    
