    .Select(p => 
	{	
		var havingLowestPrice = p.OrderByDescending(o => o.Price).First()
		return new Product
		{
		  ProductId = p.Key,
		  Name = havingLowestPrice.Name,
		  Bar = havingLowestPrice.Bar,
		  Price = havingLowestPrice.Price,
		}
	})
