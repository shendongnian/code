    public static IList<DateTime> GetWeekDays(DateTime startDate, DayOfWeek day, int count, bool pastDays)
    {
        int start = (int)startDate.DayOfWeek;
        int desired = (int)day;
        int offset;
        int diff = Math.Abs(start - desired);
        if (pastDays)
            offset = (-1) * (7 - diff);
        else
            offset = diff;
        int weekDays = pastDays ? (-1) * 7 : 7;
        DateTime firstDay = startDate.AddDays(offset);
        IList<DateTime> dates = Enumerable.Range(0, count)
            .Select(i => firstDay.AddDays(i * weekDays))
            .ToList();
        return dates;
    }
