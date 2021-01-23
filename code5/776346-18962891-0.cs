    DateTime LastFooUpdate = DateTime.MinValue;
    void FooUpdate(object state)
    {
        // check data freshness
        if ((DateTime.UtcNow - LastFooUpdate) > SomeMinimumTime)
        {
            // do update
            // and reset last update time
            LastFooUpdate = DateTime.UtcNow;
        }
        // then, reset the timer
        FooUpdateTimer.Change(TimeSpan.FromSeconds(2), TimeSpan.Infinite);
    }
