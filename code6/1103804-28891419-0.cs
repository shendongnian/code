    var r = new Random();
	var weeks = new List<List<int>>();
    const int lowerBound = 1;
    const int upperBound = 11;
		
    for (int a = 0; a < 10; a++)
    {
    	var week = new List<int>();
			
        for (int i = 0; i < 7; i++)
        {				
            week.Add(r.Next(lowerBound, upperBound));
        }
			
    	weeks.Add(week);
    }
		
	foreach (var week in weeks)
    {
		Console.Write("Week {0}: ", weeks.IndexOf(week));
		Console.WriteLine(string.Join(",", week));
	}
		
	for (int number = lowerBound; number < upperBound; number++)
    {
    	Console.WriteLine("{0} was generated {1} times", 
						  number,
						  weeks.SelectMany(n => n).Count(n => n == number));
    }
