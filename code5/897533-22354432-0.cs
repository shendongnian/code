    SystemTray.ProgressIndicator = new ProgressIndicator();
    SystemTray.ProgressIndicator.IsVisible = true;
    SystemTray.ProgressIndicator.Text = "Data is up-to-date";
    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromMilliseconds(2000);
    
    timer.Tick += (sender, args) =>
    {
        SystemTray.ProgressIndicator.IsVisible = false;
        timer.Stop();
    };
    
    timer.Start();
