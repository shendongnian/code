    List<DateTime> myDates = new List<DateTime>();
    DateTime startDate = new DateTime (2014, 6, 25);
    DateTime endDate = new DateTime (2014,7,3);
    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
    {
      myDates.Add(date);
    }
