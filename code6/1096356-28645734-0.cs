    List<Day0fWeek> openDays = GetOpenDaysFromDB();
    DateTime start = DateToStartFrom;
    int n = numberOfDays;
    
    List<DateTime> nextNOpenDays = new List<DateTime>();
    while(nextNOpenDays.Count < n)
    {
        if(openDays.Contains(start.DayOfWeek))
            nextNOpenDays.Add(start);
        start = start.AddDays(1);
    }
