    public static IEnumerable<DateTime> LoneDates(
        IEnumerable<DateTime> dates, TimeSpan threshold)
    {
        return dates.OrderBy(x => x)
            .GroupWhile((previous, current) => current - previous < threshold)
            .Select(group => group.First());
    }
