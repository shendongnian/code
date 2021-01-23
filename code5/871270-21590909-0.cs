    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
    timer.Tick += Timer_Tick;
    ...
    private void ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (timer.IsEnabled) timer.Stop();
        timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        // Do what you want now that scrolling has stopped
    }
