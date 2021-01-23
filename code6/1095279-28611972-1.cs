    var saturdays = new List<DateTime>();
    var daysInWeek = 7;
    var startDate = DateTime.Today.Subtract(TimeSpan.FromDays(13 * daysInWeek));
    // Adjust start date so it is the first Saturday after 13 weeks before today
    startDate = startDate.AddDays(DayOfWeek.Saturday - startDate.DayOfWeek);
    var endDate = DateTime.Today.Add(TimeSpan.FromDays(4 * daysInWeek));
    for (var curDate = startDate; curDate <= endDate; curDate = curDate.AddDays(daysInWeek))
    {
        saturdays.Add(curDate);
    }
    // Order by date, descending
    saturdays = saturdays.OrderByDescending(d => d).ToList();
    // Output list of Saturdays to console for verification
    saturdays.ForEach(s => Console.WriteLine(s.ToShortDateString()));
