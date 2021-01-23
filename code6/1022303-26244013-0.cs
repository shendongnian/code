    // in the constructor
    timer = new Timer();
    timer.Tick += timer_Tick;
    timer.Interval = new TimeSpan(0, 0, 5);
   
