    BaseViewModel:ViewModelBaseX
    {
      public override void OnNavigatedTo(NavigationMode mode, Uri uri, IDictionary<string, string> queryString)
      {
         // a condition is checking here & if the condition is true ,  
            i don't want to run the remaining codes in the AboutViewModel .
        if (someCondition)
        {
            NavigateToFunctionality();
        }
        else
        {
          // do nothing
         }
      }
      protected void NavigateToFunctionality()
      {
      }
    }
    AboutViewModel:BaseViewModel
    {
      public override void OnNavigatedTo(NavigationMode mode, Uri uri, IDictionary<string, string> queryString)
      {
          base.OnNavigatedTo(mode, uri, queryString);                
    
      }
      protected override void NavigateToFunctionality()
      {
        // your code goes here
      }
    }
