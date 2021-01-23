	var results = 
		data
			.GroupBy(
				x => (x.Key.Ticks / TimeSpan.TicksPerMinute + 2) / 5,
				x => x.Value)
			.Select(x => new
			{
				Key = new DateTime(x.Key * TimeSpan.TicksPerMinute * 5),
				Value = x.Average()
			});
