    public static IEnumerable<DateTime> Months(DateTime start, DateTime end)
    {
        for (DateTime date = start; date < end; date = date.AddMonths(1))
            yield return date;
    }
