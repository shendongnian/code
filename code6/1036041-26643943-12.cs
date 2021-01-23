    Stopwatch sw = Stopwatch.StartNew();
    TimeSpan lastProcessTime = TimeSpan.Zero;
    while (true)
    {
        IRampActiveTag tag;
        // wait up to 200 ms to dequeue an item.
        if (LogicBuffer.TryTake(out tag, 200))
        {
            // process here
        }
        // see if it's been 200 ms or more
        if ((sw.ElapsedMilliseconds - lastProcessTime.TotalMilliseconds) > 200)
        {
            // do periodic processing
            lastProcessTime = sw.Elapsed;
        }
    }
