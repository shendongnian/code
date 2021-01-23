    var times = new List<DateTime>
    {
        new DateTime(2014, 5, 28, 9, 57, 12),
        new DateTime(2014, 5, 28, 9, 57, 43),
        new DateTime(2014, 5, 28, 9, 58, 03),
        new DateTime(2014, 5, 28, 9, 59, 46),
        new DateTime(2014, 5, 28, 10, 0, 22),
    };
	
    var differences = new List<double>();
	
    for(int i = 0; i < times.Count - 1; i++)
    {
        differences.Add((times[i+1] - times[i]).TotalSeconds);
    }
