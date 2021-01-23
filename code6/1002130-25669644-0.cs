    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
	    indicator.Visibility = Windows.UI.Xaml.Visibility.Visible;
	    DispatcherTimer t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
	    t.Tick += (dd, ee) =>
	    {
		    t.Stop();
		    Content.Visibility = Windows.UI.Xaml.Visibility.Visible;
	    };
	    t.Start();
    }
