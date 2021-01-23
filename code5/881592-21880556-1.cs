    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = new TimeSpan(0, 0, 16);
    timer.Tick += delegate
    {
        timer.Stop();
        // your foreach code here
        foreach (Point p in blackPixels)
            ...
        timer.Start();
    };
    timer.Start();
