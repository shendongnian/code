    public void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
    	var building = ((TextBlock)sender).Text;
    	NavigationService.Navigate(new Uri("/MapLocation.xaml?building=" + building, UriKind.Relative));
    }
