    public static long GetTimestamp()
    {
        if (!Stopwatch.IsHighResolution)
        {
            DateTime utcNow = DateTime.UtcNow;
            return utcNow.Ticks;
        }
        else
        {
            long num = (long)0;
            SafeNativeMethods.QueryPerformanceCounter(out num);
            return num;
        }
    }
