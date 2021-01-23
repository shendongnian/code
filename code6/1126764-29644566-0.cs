	CustomerProductivity.Add(new ChartDataViewModel
	{
		Series = new List<string> { "Sales" },
		ChartType = "bar",
		Data = SalesStatistics
			.GroupBy(b => b.CustomerName)
			.Select(g => new ChartDataElement()
			{
				X = g.Key,
				Y = new List<int>() { (int)g.Sum(b => b.Sales) }
			}).OrderByDescending(f=> f.Y.First()).Take(3).ToList(),
		ChartConfig = config
	});
