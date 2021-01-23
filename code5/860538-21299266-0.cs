    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Do stuff
        start_timer();
    }
    private static void start_timer()
    {
        timer.Interval = CalculateInterval();
        timer.Start();
    }
    private static double CalculateInterval()
    {
        // 1 AM the next day
        return (DateTime.Now.AddDays(1).Date.AddHours(1) - DateTime.Now).TotalMilliseconds;
    }
