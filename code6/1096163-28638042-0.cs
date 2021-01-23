    public static IEnumerable<DateTime> BeginEndOfEachMonthBetween(DateTime from, DateTime to)
    {
        DateTime start = from.AddDays(1 - from.Day);
        while(start <= to)
        {
            yield return start;
            yield return start.AddMonths(1).AddDays(-1);
            start.AddMonths(1);
        }
    }
