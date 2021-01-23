    public delegate IEnumerable<DateTime> WorkingDaysGetter(DateTime x, DateTime y);
    WorkingDaysGetter g = (d1, d2) => Enumerable.Range(0, d2.Subtract(d1).Days)
                                                .Select(x => d1.AddDays(x))
                                                .Where(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
    foreach (var day in g(dt1, dt2))
    {
        Console.Write(x.Day + " ");
    }
