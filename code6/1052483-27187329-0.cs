    public static IEnumerable<DateTime> GetNearestToTime(TimeSpan targetTime, params DateTime[] dates)
    {
        var distanceLookup = dates.ToLookup(dt => (dt.TimeOfDay - targetTime).Duration());
        TimeSpan min = distanceLookup.Min(x => x.Key);
        return distanceLookup[min];
    }
