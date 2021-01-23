    DateTime today = DateTime.Today;
    DateTime start = today.AddDays(-(int) today.DayOfWeek) // Sunday...
                          .AddDays(-28);                   // 4 weeks ago
    DateTime end = start.AddDays(7 * 5);
    var result = from entry in db.Entries
                 where entry.Created >= start && entry.Created < end
                 group entry.Amount by EntityFunctions.DiffDays(start, 
                     EntityFunctions.TruncateTime(entry.Created)) / 7 into g
                 select new { Week = g.Key + 1, Sum = g.Sum() };
