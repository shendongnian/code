    private void OnPivotChanged(object sender, SelectionChangedEventArgs e)
    {
      browser.Visibility = Visibility.Collapsed;
      errorMessage.Visibility = Visibility.Collapsed;
      var newItem = e.AddedItems[0] as PivotItem;
      var site = new Uri("http://www." + newItem.Header.ToString() + ".com/");
      browser.Navigate(site);
    }
    private void OnBrowserNavigated(object sender, NavigationEventArgs e)
    {
      browser.Visibility = Visibility.Visible;
    }
    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      errorMessage.Visibility = Visibility.Visible;
    }
