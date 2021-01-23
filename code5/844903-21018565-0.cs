    static void ReadLastTimestampAndPublish()
    {
        while(true)
        {
            lock(SyncObj)
            {
                Monitor.Wait(SyncObj);
            }
            IterationToTicks.Add(Tuple.Create(Iteration, s.Elapsed.Ticks - LastTimestamp));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));   // <===
        }
    }
