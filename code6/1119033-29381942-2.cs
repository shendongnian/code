    private void Page_OnLoaded(object sender, RoutedEventArgs e)
    {
        DispatcherTimer timer = new DispatcherTimer();
    
        timer.Tick += 
            delegate(object s, EventArgs args) {
            //  code to execute
            };
    
        timer.Interval = new TimeSpan(0, 0, 1); // one second
        timer.Start();
    }
