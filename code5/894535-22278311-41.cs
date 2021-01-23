    public static IEnumerable<DateTime> getAllDates()
    {
        DateTime d = DateTime.MinValue;
        DateTime max = DateTime.MaxValue.AddHours(-1);
        while (d < max)
        {
            yield return d;
            d = d.AddHours(1);
        }
    }
