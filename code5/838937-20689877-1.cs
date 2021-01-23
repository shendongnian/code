    var eventLogs = new List<EventLogs>();
    var weekTrendGroups = eventLogs
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
    foreach (var projGroup in weekTrendGroups)
    {
        Console.WriteLine("Week " + projGroup.WeekNum);
        foreach (var proj in projGroup.WeekGroup)
            Console.WriteLine("{0} {1} {2}",
                proj.Event.EventType,
                proj.Event.EventDateTime.ToString("d"),
                proj.Event.Id);
    }
