    void RunEvents(TimeSpan interval, TimeSpan duration)
    {
        Random random = new Random();
        TimeSpan eventOffset = new TimeSpan(), sincePrevious = new TimeSpan();
        Stopwatch sw = Stopwatch.StartNew();
        while (sw.Elapsed < duration)
        {
            TimeSpan nextEvent = sincePrevious + eventOffset +
                TimeSpan.FromSeconds(random.NextDouble() * interval.TotalSeconds);
            TimeSpan delay = nextEvent - sw.Elapsed;
            if (delay.Ticks > 0)
            {
                Thread.Sleep(delay);
            }
            eventOffset += interval;
            sincePrevious = eventOffset - nextEvent;
        }
    }
