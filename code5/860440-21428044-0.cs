    namespace Administration.ViewModel
    {
        public class ViewModelLocator
        {
            public ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
                //Eager Loading
                SimpleIoc.Default.Register<UserManagementViewModel>(true);
    
                //Lazy Loading
                SimpleIoc.Default.Register<InformationManagementViewModel>();
            }
    
            public UserManagementViewModel UserManagementViewModel
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<UserManagementViewModel>();
                }
            }
    
            public InformationManagementViewModel InformationManagementViewModel
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<InformationManagementViewModel>();
                }
            }
    
            public static void Cleanup()
            {
                SimpleIoc.Default.Unregister<UserManagementViewModel>();
                SimpleIoc.Default.Unregister<InformationManagementViewModel>();
            }
        }
    }
