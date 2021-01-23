    public static IEnumerable<DateTime> getAllDates()
    {
        DateTime d = DateTime.MinValue;
        DateTime max = DateTime.MaxValue.AddDays(-1);
        while (d < max)
        {
            yield return d;
            d = d.AddDays(1);
        }
    }
