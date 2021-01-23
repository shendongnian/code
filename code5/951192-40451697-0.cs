    public TimeSpan RoundTimeSpanUp(TimeSpan span, TimeSpan roundingTimeSpan)
    {
        long originalTicks = roundingTimeSpan.Ticks;
        long roundedTicks = (long)(Math.Ceiling((double)span.Ticks / originalTicks) * originalTicks);
        TimeSpan result = new TimeSpan(roundedTicks);
        return result;
    }
 
