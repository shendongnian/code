    public static TimeSpan RoundToNearest15Mins(TimeSpan input)
    {
        var tempSpan = input + new TimeSpan(0, 7, 0);
        var minutes = (int)tempSpan.TotalMinutes;
        return new TimeSpan(0, minutes - minutes % 15, 0);
    }
