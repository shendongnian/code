    DateTime startDate = new DateTime(2013, 11, 19);
    DateTime endDate = new DateTime(2013, 11, 28);
    List<DateTime> list = new List<DateTime>();
    while (startDate <= endDate)
    {
        if (startDate.DayOfWeek == DayOfWeek.Wednesday)
        {
            list.Add(startDate);
        }
        startDate = startDate.AddDays(1);
    }
