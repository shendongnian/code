    var startDate = new DateTime(2014,11,16);
    var endDate = startDate.AddDays(7);
    List<DateTime> myDates = Enumerable
               .Range(0, (int)((endDate - startDate).TotalDays))
               .Select(x => startDate.AddDays(x))
               .ToList();
