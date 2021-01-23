    var r = new Random();
	var weeks = new List<List<int>>();
		
    for (int a = 0; a < 10; a++)
    {
    	var week = new List<int>();
			
        for (int i = 0; i < 7; i++)
        {				
            week.Add(r.Next(1, 11));
        }
			
    	weeks.Add(week);
    }
		
	foreach (var week in weeks)
    {
		Console.WriteLine("Week {0}: {1}", weeks.IndexOf(week), string.Join(",", week));
	}
		
    var allNumbers = weeks.SelectMany(n => n);
	foreach (var number in allNumbers.Distinct().OrderBy(n => n))
	{
		Console.WriteLine("{0} was generated {1} times", 
						  number,
						  allNumbers.Count(n => n == number));
	}
