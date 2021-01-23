    protected async override void OnNavigatedFrom(NavigationEventArgs e)
    {
        Debug.WriteLine("OnNavigatedFrom");
        Hub.Background = new SolidColorBrush(Colors.Red);
        this.navigationHelper.OnNavigatedFrom(e);
    }
