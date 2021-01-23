    var weekDays = (int)daysOfWeek;
    var weekDayEnumerable = Enumerable
        .Range(0, 7)
        .Where(i => { var isMatch = (weekDays & 1) == 1; weekDays >>= 1; return isMatch; })
        .Select(i => (DayOfWeek)i)
        .ToList();
