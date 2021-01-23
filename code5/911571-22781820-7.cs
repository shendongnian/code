    public static IEnumerable<DateTime> Hours(DateTime start, DateTime end)
    {
        start -= TimeSpan.FromMinutes(start.TimeOfDay.TotalMinutes);
        end -= TimeSpan.FromMinutes(end.TimeOfDay.TotalMinutes);
        return Enumerable.Range(0, (int)Math.Ceiling((end - start).TotalHours))
            .Select(x => begin + TimeSpan.FromHours(x));
    }
