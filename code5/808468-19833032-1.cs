    static DateTime GetDTCTime(ulong nanoseconds, ulong ticksPerNanosecond)
    {
        DateTime pointOfReference = new DateTime(2000, 01, 01);
        long ticks = (long)(nanoseconds / ticksPerNanosecond);
        return pointOfReference.AddTicks(ticks);
    }
            
    static DateTime GetDTCTime(ulong nanoseconds)
    {
        return GetDTCTime(nanoseconds, 100);
    }
