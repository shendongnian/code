    var dates = new List<cSingleDate>();
    foreach(var date in cDates)
    { 
        while(date.PeriodStart <= date.PeriodEnd)
        { 
            dates.Add(new cSingleDate { SingleDate = date.PeriodStart });
            date.PeriodStart = date.PeriodStart.AddDays(1);
        }
    }
