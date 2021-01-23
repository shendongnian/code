    ealed partial class App
    {
        readonly IUnityContainer _container = new UnityContainer();
        readonly RegionManager _regionManager = new RegionManager();
        public App()
        {
            InitializeComponent();
        }
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }
        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);
            _container.RegisterInstance(SessionStateService);
            _container.RegisterInstance(NavigationService);
            _container.RegisterInstance(_regionManager);
            _container.RegisterInstance<IEventAggregator>(new EventAggregator());
            ViewModelLocationProvider.SetDefaultViewModelFactory(viewModelType => _container.Resolve(viewModelType));
            InizializeRegionManager();
            return Task.FromResult<object>(null);
        }
        private void InizializeRegionManager()
        {
            var region = _container.Resolve<RegionManager>();
            region.RegisterViewWithRegion("RegionName", () => _container.Resolve<RegionView>());
        }
