    using Cimbalino.Phone.Toolkit.Services; 
        using GalaSoft.MvvmLight; 
        using GalaSoft.MvvmLight.Ioc; 
        using Microsoft.Practices.ServiceLocation; 
     
        /// <summary> 
        /// This class contains static references to all the view models in the 
        /// application and provides an entry point for the bindings. 
        /// </summary> 
        public class ViewModelLocator 
        { 
            /// <summary> 
            /// Initializes a new instance of the ViewModelLocator class. 
            /// </summary> 
            public ViewModelLocator() 
            { 
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default); 
                if (!SimpleIoc.Default.IsRegistered<IScreenshotService>()) 
                { 
                    SimpleIoc.Default.Register<IScreenshotService, ScreenshotService>(); 
                } 
                SimpleIoc.Default.Register<MainViewModel>(); 
            } 
     
            /// <summary> 
            /// Gets the main view model. 
            /// </summary> 
            /// <value> 
            /// The main view model. 
            /// </value> 
            public MainViewModel MainViewModel 
            { 
                get 
                { 
                    return ServiceLocator.Current.GetInstance<MainViewModel>(); 
                } 
            } 
             
            public static void Cleanup() 
            { 
                // TODO Clear the ViewModels 
                var viewModelLocator = (ViewModelLocator)App.Current.Resources["Locator"]; 
                viewModelLocator.MainViewModel.Cleanup(); 
            } 
        }
