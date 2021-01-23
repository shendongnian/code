    .Select(p => 
	{	
		var havingHighestPrice = p.OrderByDescending(o => o.Price).First()
		return new Product
		{
		  ProductId = p.Key,
		  Name = havingHighestPrice.Name,
		  Bar = havingHighestPrice.Bar,
		  Price = havingHighestPrice.Price,
		}
	})
