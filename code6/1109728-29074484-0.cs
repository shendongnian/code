    List<DateTimeRange> availableTimes = new List<DateTimeRange>()
    {
        new DateTimeRange(new DateTime(2015, 3, 16, 00, 00, 00), new DateTime(2015, 3, 16, 1, 00, 00)),
        new DateTimeRange(new DateTime(2015, 3, 16, 08, 00, 00), new DateTime(2015, 3, 16, 10, 00, 00)),
        new DateTimeRange(new DateTime(2015, 3, 16, 12, 00, 00), new DateTime(2015, 3, 16, 14, 00, 00)),
        new DateTimeRange(new DateTime(2015, 3, 16, 15, 00, 00), new DateTime(2015, 3, 16, 16, 00, 00)),
        new DateTimeRange(new DateTime(2015, 3, 16, 19, 00, 00), new DateTime(2015, 3, 16, 23, 59, 59)),
    };
    var gap = GetGapsForDay(availableTimes);
    
    public IEnumerable<DateTimeRange> GetGapsForDay(List<DateTimeRange> ranges)
    {
        var start = ranges.First().StartDate.Date;
        var end = ranges.First().StartDate.Date.AddDays(1).AddMinutes(-1);
    
        foreach(var item in ranges.OrderBy(i => i.StartDate))
        {
            if(start < item.StartDate)
                yield return new DateTimeRange(start, item.StartDate);
    
            start = item.EndDate;
        }
        if (ranges.Max(i => i.EndDate) < end)
            yield return new DateTimeRange(start, end);
    }
