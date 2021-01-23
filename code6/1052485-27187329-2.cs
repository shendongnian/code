    public static IEnumerable<DateTime> GetNearestToTime(TimeSpan targetTime, params DateTime[] dates)
    {
        TimeSpan negativeTarget = TimeSpan.FromHours(24) - targetTime;
        var dateInfos = dates
            .Select(dt => new
            {
                DateTime = dt,
                MinDistance = new[] { (dt.TimeOfDay - targetTime).Duration(), (dt.TimeOfDay - negativeTarget).Duration() }.Min()
            });
        var distanceLookup = dateInfos.ToLookup(x => x.MinDistance);
        TimeSpan min = distanceLookup.Min(x => x.Key);
        return distanceLookup[min].Select(x => x.DateTime);
    }
