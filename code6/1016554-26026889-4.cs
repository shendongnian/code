    DispatcherTimer _timer;  //  member of class
    
    //  Add Following to constructor
    _timer = new DispatcherTimer();
    _timer.Interval = new TimeSpan(0, 0, 1);  // 1 second
    _timer.Tick += _timer_Tick;
    //  Timer Routine
    void _timer_Tick(object sender, object e)
    {
        _timer.Stop();
        DrawToFile();
    }
