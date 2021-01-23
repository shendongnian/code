    DateTime[] times = new DateTime[6];
    times[0] = new DateTime(2014, 09, 1, 11, 54, 40);
    times[1] = new DateTime(2014, 09, 1, 11, 55, 40);
    times[2] = new DateTime(2014, 09, 1, 11, 57, 40); 
    times[3] = new DateTime(2014, 09, 1, 12, 00, 40);
    times[4] = new DateTime(2014, 09, 1, 12, 01, 40);
    times[5] = new DateTime(2014, 09, 1, 12, 12, 40);
    
    var start = times[0];
    var end = times[times.Length - 1];
    
    var result = new List<DateTime>(); //The complete range
    while (start <= end)
    {
    	result.Add(start);
    	start = start.AddMinutes(1);
    }
    
    var missing = result.Except(times); //The missing datetimes
