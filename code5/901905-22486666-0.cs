    List<DateTime> dates = new List<DateTime>();
    int totalDays = endTime.Subtract(startTime).TotalDays;
    for (var i = 1; i < totalDays; i++)
    {
        dates.Add(startTime.AddDays(i));
    }
