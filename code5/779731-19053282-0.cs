    public static IEnumerable<DateTime> Days(DateTime start)
    {
        while (true)
        {
            yield return start;
            start = start.AddDays(1);
        }
    }
