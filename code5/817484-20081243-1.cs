    DateTime startDate = new DateTime(2013, 11, 19);
    DateTime endDate = new DateTime(2013, 11, 28);
    string[] WeekDayNames = new[] { "Wednesday" };
    List<DateTime> list = new List<DateTime>();
    while (startDate <= endDate)
    {
        if (WeekDayNames.Any(r=> r==  startDate.DayOfWeek.ToString()))
        {
            list.Add(startDate);
        }
        startDate = startDate.AddDays(1);
    }
