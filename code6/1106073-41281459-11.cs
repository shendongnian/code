    public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
              
            }
    
            public void ShowFirstView()
            {
                ServiceLocator.Current.GetInstance<ViewModelFirstNavigationService>().NavigateTo<LoginViewModel>();
                //To navigate wherever you want you just need to call this method, replacing LoginViewModel with YourViewModel
            }
        }
