    private static HashSet<Timer> timers = new HashSet<Timer>();
    public static void ExecuteAfter(Action action, TimeSpan delay)
    {
        Timer timer = null;
        timer = new System.Threading.Timer(s =>
        {
            action();
            timer.Dispose();
            lock (timers)
                timers.Remove(timer);
        }, null, (long)delay.TotalMilliseconds, Timeout.Infinite);
        lock (timers)
            timers.Add(timer);
    }
