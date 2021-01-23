    int MilliSecondsLeftTilTheHour()
    {
        int interval;
        int minutesRemaining = 59 - DateTime.Now.Minute;
        int secondsRemaining = 59 - DateTime.Now.Second;
        interval = ((minutesRemaining * 60) + secondsRemaining) * 1000;
        // If we happen to be exactly on the hour...
        if (interval == 0)
        {
            interval = 60 * 60 * 1000;
        }
        return interval;
    }
    
    Timer timer = new Timer();
    timer.Tick += timer_Tick;
    timer.Enabled = true;
    timer.Interval = MilliSecondsLeftTilTheHour();
