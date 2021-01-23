    DateTime myDateTime = new DateTime(2015, 1, 25);
    
    var remainedDateTimesToNextMonth = new List<DateTime>();
	var nextDay = myDateTime ;
    while(true)
    {
        nextDay = nextDay.AddDays(1);
    	if (nextDay.Month == myDateTime.Month)
    	{
    		remainedDateTimesToNextMonth.Add(nextDay);
    	}
    	else break;
    }
