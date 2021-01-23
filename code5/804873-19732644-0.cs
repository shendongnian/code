    public static IEnumerable<DateTime> Days(DateTime start, DateTime end)
    {
        DateTime current = start;
        while (current < end)
        {
            yield return current;
            current = current.AddDays(1);
        }
    }
