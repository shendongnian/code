    public class MyContent : UserControl, IContent
    {
      public void OnFragmentNavigation(FragmentNavigationEventArgs e)
      {
      }
      public void OnNavigatedFrom(NavigationEventArgs e)
      {
      }
      public void OnNavigatedTo(NavigationEventArgs e)
      {
        //Refresh your page here
      }
      public void OnNavigatingFrom(NavigatingCancelEventArgs e)
      {
        // ask user if navigating away is ok
        if (ModernDialog.ShowMessage("Navigate away?", "navigate", MessageBoxButton.YesNo) == MessageBoxResult.No) {
          e.Cancel = true;
        }
      }
    }
