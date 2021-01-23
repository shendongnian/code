    var startDate = DateTime.Now.AddDays(-26);
    var endDate = DateTime.Now.AddDays(1);
    
    var weeks = new List<Tuple<DateTime, DateTime>>();
    for (var date = startDate; date <= endDate; date = date.AddDays(1))
    {
    	if (date == startDate)
    	{
    		// find the next Sunday 
    		var start = (int)date.DayOfWeek;
    		var target = (int)DayOfWeek.Sunday;
    		if (target < start)
    			target += 7;
    		weeks.Add(Tuple.Create(date, date.AddDays(target - start)));
    	}
    	else if (date.DayOfWeek == DayOfWeek.Monday)
    	{
    		weeks.Add(Tuple.Create(date, date.AddDays(6)));
    	}
    }
