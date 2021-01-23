    DateTime dUtcEnd = DateTime.UtcNow.Date;
    DateTime dUtcStart = dUtcEnd.AddDays(-13);
    var eventLogs = new List<EventLogs>();
    var weekTrendGroups = eventLogs
        .Where(x => x.EventDateTime >= dUtcStart 
                    && x.EventDateTime <= dUtcEnd
                    && x.EventType == "some event")
        .Select(p => new
        {
            Event = p,
            Year = p.EventDateTime.Year,
            Week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                    (p.EventDateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        })
        .GroupBy(x => new { x.Year, x.Week })
        .Select((g, i) => new
        {
            WeekGroup = g,
            WeekNum = i + 1,
            Year = g.Key.Year,
            CalendarWeek = g.Key.Week
        });
    foreach (var eventLogGroup in weekTrendGroups)
    {
        Console.WriteLine("Week " + eventLogGroup.WeekNum);
        foreach (var proj in eventLogGroup.WeekGroup)
            Console.WriteLine("{0} {1} {2}",
                proj.Event.EventType,
                proj.Event.EventDateTime.ToString("d"),
                proj.Event.Id);
    }
