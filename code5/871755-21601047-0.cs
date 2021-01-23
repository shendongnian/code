    public static DateTime NextDate(DateTime seed, int[] days)
    {
        return Enumerable.Range(0, int.MaxValue)
            .Select(i => seed.AddDays(i))
            .First(d => days.Contains(d.Day));
    }
