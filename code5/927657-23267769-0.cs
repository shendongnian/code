    public class BaseViewModel : ViewModelBaseX
    {
     
    
           protected virtual void HandleNavigatedTo(NavigationMode mode, Uri uri, IDictionary<string, string> queryString)
            {
            }
            
            public override void OnNavigatedTo(NavigationMode mode, Uri uri, IDictionary<string, string> queryString)
            {
                if (condition)
                {
                    HandleNavigatedTo(mode, uri, queryString);
                 }
            }
        }
            
        public class AboutViewModel:BaseViewModel
        {
              public override void HandleNavigatedTo(NavigationMode mode, Uri uri, IDictionary<string, string> queryString)
              {
                  // here some code to be execute 
              }
         }
