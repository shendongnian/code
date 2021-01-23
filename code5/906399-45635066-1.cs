    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
    timer.Tick += (s, e) =>
    {
        if (GetIdleTime() > 10*60) // 10 min
            ShowWindow();
        else
            HideWindow();
    };
