    // creating timer instance
    DispatcherTimer newTimer = new DispatcherTimer();
    // timer interval specified as 1 second
    newTimer.Interval = TimeSpan.FromSeconds(1);
    // Sub-routine OnTimerTick will be called at every 1 second
    newTimer.Tick += OnTimerTick;
    // starting the timer
    newTimer.Start();
