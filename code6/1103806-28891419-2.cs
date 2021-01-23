    var r = new Random();
	var weeks = new List<List<int>>(
        Enumerable.Range(0, 10)
				  .Select(w => new List<int>(Enumerable.Range(0, 7)
													   .Select(i => r.Next(1, 11)))));	
		
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
