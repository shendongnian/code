    public static TimeSpan GetPeriod(DateTime start, DateTime end, params DateTime[] exclude)
    {
        var span = end - start;
        if (exclude == null) return span;
        span = exclude.Where(d => d >= start && d <= end)
        .Aggregate(span, (current, date) => current.Subtract(new TimeSpan(1, 0, 0, 0)));
        return span;
    }
