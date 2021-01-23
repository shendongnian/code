    public static bool IsOnTick(DateTime start, TimeSpan interval, 
        DateTime dateToTest)
    {
        return (dateToTest - start).Ticks % interval.Ticks == 0;
    }
