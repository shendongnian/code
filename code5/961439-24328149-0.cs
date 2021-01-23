    if (rb1.IsChecked.Value)
    {
    	NavigationService.Navigate(new Uri("/enterque.xaml?chkd=" + rb1.IsChecked,UriKind.Relative));
    	App.radVisibility = Visibility.Collapsed;               
    	this.rb1.Visibility = App.radVisibility;
    }
    
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	this.rb1.Visibility = App.radVisibility;
    }
