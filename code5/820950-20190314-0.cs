    public static IList<DateTime> GetWeekDays(DateTime startDate, DayOfWeek day, int count, bool pastDays)
    {
        int start = (int)startDate.DayOfWeek;
        int desired = (int)day;
        int offset;
        int diff = Math.Abs(start - desired);
        if(pastDays)
            offset = (-1) * (7 - diff);
        else
            offset = diff;
        DateTime firstDay = startDate.AddDays(offset);
        IList<DateTime> dates = Enumerable.Range(0, count)
            .Select(i => firstDay.AddDays(i * 7))
            .ToList();
        return dates;
    }
