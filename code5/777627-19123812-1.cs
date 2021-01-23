    static DispatcherTimer dt = new DispatcherTimer();
    static LastInput()
    {
        dt.Tick += dt_Tick;
    }
    static void dt_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var timeSinceInput = TimeSpan.FromTicks(GetLastInputTime());
 
        if (timeSinceInput < TimeSpan.FromMinutes(5))
        {
            timer.Interval = TimeSpan.FromMinutes(5) - timeSinceInput;
        }
        else
        {
            timer.Interval = TimeSpan.FromMinutes(5);
            //Do stuff here
        }
    }
