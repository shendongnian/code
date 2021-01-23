    var groups = events
    .GroupBy(ev => ev.Starts.Date)
    .Select(dateGroup => new
    {
        DateGroup = new { Date = dateGroup.Key, Events = dateGroup.ToList() },
        ListOfTimeGroup = dateGroup
            .GroupBy(dg => dg.Starts.TimeOfDay)
            .ToList()
    }).ToList();
    foreach (var group in groups)
    {
        DateTime date = group.DateGroup.Date;
        List<Event> dateEvents = group.DateGroup.Events;
        Console.WriteLine(string.Join(",", dateEvents));
        foreach( var timeGroup in group.ListOfTimeGroup)
        {
            TimeSpan timeOfday = timeGroup.Key;
            List<Event> timeEventList = timeGroup.ToList();
            Console.WriteLine(string.Join(",", timeEventList));
        }
    }
