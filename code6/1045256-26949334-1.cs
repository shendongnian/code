    public static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        var timer = (TimerWithRunCounter)sender;
        lock (lockObject)
        {
            Console.WriteLine("Run {0}", timer.Counter);
            timer.Counter++;
        }
    }
