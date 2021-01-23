     void Browser_Navigating(object sender,     NavigatingEventArgs e)
          {
              ProgBar.Visibility = Visibility.Visible;
          }
     void Browser_Navigated(object sender,     System.Windows.Navigation.NavigationEventArgs e)
          {
              ProgBar.Visibility = Visibility.Collapsed;
          }
