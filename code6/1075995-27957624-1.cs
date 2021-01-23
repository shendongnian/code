    private static readonly TimeSpan minInterval = TimeSpan.FromSeconds(1);
    private void CodeConsumer()
    {
        TimeSpan lastCode = TimeSpan.MinValue;
        Stopwatch sw = Stopwatch.StartNew();
        foreach (string code in codes.GetConsumingEnumerable())
        {
            TimeSpan interval = sw.Elapsed - lastCode;
            if (interval < minInterval)
            {
                Thread.Sleep(minInterval - interval);
            }
            ProcessOneCode(code);
        }
    }
