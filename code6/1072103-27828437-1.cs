    static void DoSomething(...)
    {
       timer.Stop();
       timer.Interval = TimerMilliseconds();
       ...
       timer.Start();
    }
