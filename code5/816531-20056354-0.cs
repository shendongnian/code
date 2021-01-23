    public static DateTime GetSoonestDrawDate(this DateTime from, IEnumerable<DayOfWeek> drawDates)
    {
        var realDrawDates = drawDates.SelectMany(x => new[] { (int)x, (int)x + 7 }).OrderBy(x => x);
        var difference = realDrawDates.SkipWhile(x => x < (int)from.DayOfWeek).First() - (int)from.DayOfWeek;
        return from.AddDays(difference);
    }
