    using System.Timers;
    private void Main()
    {
        Timer t = new Timer();
        t.Interval = 5000; // 5 seconds
        t.AutoReset = true;
        t.Elapsed += new SleepDone(TimerElapsed);
        t.Start();
    }
    
    private void SleepDone(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("HERE WHAT COME AFTER SLEEP");
    }
