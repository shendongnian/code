        {
			var dStart = new DateTime(2015,2,12,1,15,0);			
			var dEnd = new DateTime(2015,2,12,1,15,0);
			var x = Enumerable.Range(0, (dEnd.Date-dStart.Date).Days + 1)
                              .Select(c=>Tuple.Create(
                                         Max(dStart.Date.AddDays(c),dStart), 
                                         Min(dStart.Date.AddDays(c+1).AddMinutes(-1), dEnd)
                                     ));
        }
		private static DateTime Min(DateTime a, DateTime b)
		{
			if (a>b)
				return b;
			return a;
		}
		
		private static DateTime Max(DateTime a, DateTime b)
		{
			if (a<b)
				return b;
			return a;
		}
