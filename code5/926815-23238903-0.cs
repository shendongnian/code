    public IEnumerable<DateTime> GenerateDates(DateTime start, DateTime end)
    {
      var dates = new List<DateTime>();
      var date = new DateTime(start.Year, start.Month, start.Day);
      while (date.Month <= end.Month && date.Year <= end.Year)
      {
        date = date.AddMonths(1);
        dates.Add(date);
      }
      return dates;
    } 
