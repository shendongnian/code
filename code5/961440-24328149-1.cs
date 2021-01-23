    if (rb1.IsChecked.Value)
    {
    	App.radVisibility = Visibility.Collapsed;               
    	this.rb1.Visibility = App.radVisibility;
    	NavigationService.Navigate(new Uri("/enterque.xaml?chkd=" + rb1.IsChecked,UriKind.Relative));
    }
    
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	this.rb1.Visibility = App.radVisibility;
    }
