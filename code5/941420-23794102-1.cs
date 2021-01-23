    Customers
	.OrderBy( x=>x.Name )
	.Select ( x => new
	{
		x.Name,
		Items = x.Purchases
		.Select( y => new
		{
			y.CustomerID, y.Description
		})
	})
