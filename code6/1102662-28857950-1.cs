	void Main()
	{
		var input = new List<Interval>
		{
			new Interval { Name = "a", Min = 3, Max = 13 },
			new Interval { Name = "b", Min = 11, Max = 20 },
			new Interval { Name = "c", Min = 16, Max = 21 },
			new Interval { Name = "z", Min = 200, Max = 250 }
		};
		
		var interval = new Interval { Name = "search", Min = 12, Max = 13 };
		
        // Don't forget the third case when the interval 
        // you're looking for is inside your input intervals
        // Min = 210, Max = 220 should return "z"
		var result = input.Where(i => (interval.Min <= i.Min && i.Min <= interval.Max) ||
								      (interval.Min <= i.Max && i.Max <= interval.Max) ||
									  (i.Min <= interval.Min && interval.Max <= i.Max));
	}
	
	class Interval
	{
		public string Name;
		public int Min;
		public int Max;
	}
