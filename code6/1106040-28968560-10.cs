    static ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
                SetupNavigation();
    
                SimpleIoc.Default.Register<MainViewModel>();
                SimpleIoc.Default.Register<LoginViewModel>();
                SimpleIoc.Default.Register<NoteViewModel>();            
            }
     private static void SetupNavigation()
            {
                var navigationService = new FrameNavigationService();
                navigationService.Configure("LoginView", new Uri("../Views/LoginView.xaml",UriKind.Relative));
                navigationService.Configure("Notes", new Uri("../Views/NotesView.xaml", UriKind.Relative));            
    
                SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            }
