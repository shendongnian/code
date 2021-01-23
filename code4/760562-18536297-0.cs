    public static IEnumerable<DateTime> LoneDates(
        IEnumerable<DateTime> dates, TimeSpan threshold)
    {
        return dates.Where(date => !dates.Any(other => date - other < threshold));
    }
