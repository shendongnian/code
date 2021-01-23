    namespace SomeNamespace.ViewModel
    {
        // This class contains static references to all the view models 
        // in the application and provides an entry point for the bindings.
        public class ViewModelLocator
        {
            static ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<LoginViewModel>();
            }
            // Reference to your viewmodel    
            public LoginViewModel LoginVM 
            { 
                get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } 
            }
    
            ...
        }
        ...
    }
