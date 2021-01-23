	void Main()
	{	
		var startDate = new [] { 1, 2, 3, 1, 6, 7, 7 };
		var endDate = new [] { 3, 3, 4, 5, 7, 8, 10 };
		var maxCallsCount = 0;
		var secondAtMaxCallsCount = 0;
		
		foreach (var second in Enumerable.Range(startDate.Min(), 
                                                endDate.Max() - startDate.Min() + 1))
		{
			var callsCount = 0;
			
			for (var i = 0; i < startDate.Length; ++i)
			{
				if (startDate[i] <= second && second <= endDate[i])
				{
					++callsCount;
				}
			}
			
			if (callsCount > maxCallsCount)
			{
				maxCallsCount = callsCount;
				secondAtMaxCallsCount = second;
			}
		}
		
		Console.WriteLine("Max calls count is " + maxCallsCount + 
						  " at " + secondAtMaxCallsCount + " second");
	}
