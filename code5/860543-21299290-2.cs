    static Timer timer;
    static void Main(string[] args)
    {
        setup_Timer();
    }
    
    static void setup_Timer()
    {
        DateTime nowTime = DateTime.Now;
        DateTime oneAmTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 0, 1, 0, 0);
        if (nowTime > oneAmTime)
            oneAmTime = oneAmTime.AddDays(1);
    
        double tickTime = (oneAmTime - nowTime).TotalMilliseconds;
        timer = new Timer(tickTime);
        timer.Elapsed += timer_Elapsed;
        timer.Start();
    }
    
    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        timer.Stop();
        //process code..
        setup_Timer();
    }
