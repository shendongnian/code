    public void Event_ViewAction(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("Edit clicked");			
      this.NavigationService.StopLoading();			
    }
