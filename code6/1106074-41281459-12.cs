     public class ViewModelLocator
        {
            public ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<MainViewModel>();
                ViewModelFirstNavigationService navService = new ViewModelFirstNavigationService(Main);
                SimpleIoc.Default.Register<LoginViewModel>();
                navService.AddNavigableElement(SimpleIoc.Default.GetInstance<LoginViewModel>);
                // so whenever you want to add a new navigabel View Model just add these lines here
                // SimpleIoc.Default.Register<YourViewModel>();
                // navService.AddNavigableElement(SimpleIoc.Default.GetInstance<YourViewModel>);
                SimpleIoc.Default.Register<ViewModelFirstNavigationService>(() => navService);
            }
    
            public MainViewModel Main
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<MainViewModel>();
                }
            }
            
            public static void Cleanup()
            {
            }
        }
