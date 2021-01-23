    string[] WeekDayNames = new[] { "Monday","Wednesday" };
    DayOfWeek[] days = WeekDayNames
        .Select(s => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), s))
        .ToArray();
    DateTime start = new DateTime(2013, 11, 19);
    DateTime end = new DateTime(2013, 11, 28);
