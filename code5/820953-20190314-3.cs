    public static IList<DateTime> GetWeekDays(DateTime startDate, DayOfWeek day, int count, bool pastDays, bool includeStartDate)
    {
        int start = (int)startDate.DayOfWeek;
        int desired = (int)day;
        int offset;
        int diff = Math.Abs(start - desired);
        if(!includeStartDate && start == desired)
            diff = 7;
        offset = pastDays ? (-1) * diff : diff;
        int weekDays = pastDays ? (-1) * 7 : 7;
        DateTime firstDay = startDate.AddDays(offset);
        IList<DateTime> dates = Enumerable.Range(0, count)
            .Select(i => firstDay.AddDays(i * weekDays))
            .ToList();
        return dates;
    }
