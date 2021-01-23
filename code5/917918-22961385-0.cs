	var items = new []
	{
		new PricesAtTimeX
		{
			ID = 1,
			Date = DateTime.Now.AddDays(-3),
			ApplePrice = 10,
			BananaPrice = 20
		},
		new PricesAtTimeX
		{
			ID = 1,
			Date = DateTime.Now.AddDays(-2),
			ApplePrice = 12,
			BananaPrice = 20
		},
		new PricesAtTimeX
		{
			ID = 1,
			Date = DateTime.Now.AddDays(-1),
			ApplePrice = 14,
			BananaPrice = 10
		},
		new PricesAtTimeX
		{
			ID = 1,
			Date = DateTime.Now,
			ApplePrice = 17,
			BananaPrice = 7
		},
	};
	
	var result = new[]
	{
		new 
		{
			key = "BananaPrices",
			values =  items.Select(i => new object[]{i.Date, i.BananaPrice})
		},
		new 
		{
			key = "ApplePrices",
			values =  items.Select(i => new object[]{i.Date, i.ApplePrice})
		},
	};
	var json = JsonConvert.SerializeObject(result);
