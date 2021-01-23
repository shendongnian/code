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
    }
