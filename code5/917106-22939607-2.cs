    var startDate = new DateTime(2014, 04, 06, 11, 30, 0, 0, 0);
    var endDate = new DateTime(2014, 04, 08, 10, 15, 0, 0, 0);
		
    var openStart = new DateTime(2014, 04, 08, 9, 0, 0);
    var openEnd = new DateTime(2014, 04, 08, 17, 0, 0);;
    var totalAffected = TimeSpan.Zero;
    var checkDate = startDate;
    while (checkDate < endDate)
    {
        if (IsWorkDay(checkDate))
        {
            totalAffected = totalAffected.Add(openEnd.TimeOfDay - openStart.TimeOfDay);    
        }
        
        checkDate = checkDate.AddDays(1);
    }
    if (IsWorkDay(checkDate))
    {
        if (endDate.TimeOfDay > openEnd.TimeOfDay)
        {
	        totalAffected = totalAffected.Add(openEnd.TimeOfDay - openStart.TimeOfDay);
        }
        else
        {
	        totalAffected = totalAffected.Add(endDate.TimeOfDay - openStart.TimeOfDay);
        }
    }
    double numberOfAffectedHours = totalAffected.TotalHours;
    private bool IsWorkDay(DateTime day)
    {
        return !(day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday);
    }
