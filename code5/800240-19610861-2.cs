        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<UserCredentialsVM>(true);
            SimpleIoc.Default.Register<BrowserSelectionVM>(true);
            SimpleIoc.Default.Register<MainViewModel>();
        }
        public UserCredentialsVM UserCredentialsVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserCredentialsVM>();
            }
        }
        public BrowserSelectionVM BrowserSelectionVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BrowserSelectionVM>();
            }
        }
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public static void Cleanup()
        {
        }
