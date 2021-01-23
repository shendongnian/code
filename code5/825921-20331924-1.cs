    SystemEvents.TimeChanged += SystemEvents_TimeChanged;
    static void SystemEvents_TimeChanged(object sender, EventArgs e)
    {
        timer.Dispose();//Dispose your previous timer
        SetTimerAgain();//Call the method which sets the timer again. you're done
    }
