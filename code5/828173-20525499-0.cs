    DispatcherTimer timer = new DispatcherTimer();
    
    timer.Interval = new TimeSpan(0, 0, 0, 0, 20); // 20ms
    timer.Tick += new EventHandler(timer_Tick);
    timer.Start();
