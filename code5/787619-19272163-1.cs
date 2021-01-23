    public static long GetTimestamp()
    {
        if (!Stopwatch.IsHighResolution)
        {
            DateTime utcNow = DateTime.UtcNow;
            return utcNow.Ticks; //There are 10,000 of these ticks in a second
        }
        else
        {
            long num = (long)0;
            SafeNativeMethods.QueryPerformanceCounter(out num);
            return num; //These ticks depend on the processor, and
                        //later will be converted to 1/10000 of a second
        }
    }
