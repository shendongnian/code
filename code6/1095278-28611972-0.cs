    var saturdays = new List<DateTime>();
    var daysInWeek = 7;
    var startDate = DateTime.Today.Subtract(TimeSpan.FromDays(13 * daysInWeek));
    var endDate = DateTime.Today.Add(TimeSpan.FromDays(4 * daysInWeek));
    for (var curDate = startDate; curDate <= endDate; curDate = curDate.AddDays(1))
    {
        if (curDate.DayOfWeek == DayOfWeek.Saturday) saturdays.Add(curDate);
    }
    // Order by date, descending
    saturdays = saturdays.OrderByDescending(d => d).ToList();
    // Output list of Saturdays to console for verification
    saturdays.ForEach(s => Console.WriteLine(s.ToShortDateString()));
