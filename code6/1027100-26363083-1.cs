      // Get 5 2-week intervals 
      List<DateTime> intervals2Weeks = Occurrencies
        .FindInterval(DateTime.Now, TimePeriod.Week, 2)
        .Take(5)
        .ToList();
    
      // Get 11 3-month intervals 
      List<DateTime> intervals2Weeks = Occurrencies
        .FindInterval(DateTime.Now, TimePeriod.Month, 3)
        .Take(11)
        .ToList();
