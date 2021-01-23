	Data = new Data(
		transactions.Select(t => 
			(object)new object[] 
			{
				(int)t.Volume,
				(int)t.Price,
				t.TermDate.DayOfYear
			}
		)
		.ToArray()
	)
