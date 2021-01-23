	public static void Main()
	{
		var start = DateTime.Now;
		var saturdays = GetSaturdays(start, 13, 4).OrderBy(d => Math.Abs((start - d).Days));
		foreach (var s in saturdays) 
		{
			Console.WriteLine(s.ToLongDateString());
		}
	}
	
	public static IEnumerable<DateTime> GetSaturdays(DateTime start, int weeksBack, int weeksForward)
	{
		var startingSat = start.AddDays(6 - (int)start.DayOfWeek);
		for (int i = -weeksBack; i < weeksForward; i++)
		{
			yield return startingSat.AddDays(i * 7);
		}
	}
