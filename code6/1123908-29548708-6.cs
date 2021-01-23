    // Query Example 1
    IQueryable<XElement> sqlQuery =
	from c in Customers
		select 
			new XElement ("customer", new XAttribute ("id", c.ID),
				new XElement ("name", c.Name),
				new XElement ("buys", c.Purchases.Count)
			);
    var customers = new XElement ("customers", sqlQuery);
    // Query Example 2
    new XElement ("customers",
	from c in Customers
		let lastBigBuy = (
			from p in c.Purchases
			where p.Price > 1000
			orderby p.Date descending
			select p
		).FirstOrDefault()
	    select 
		new XElement ("customer", new XAttribute ("id", c.ID),
			new XElement ("name", c.Name),
			new XElement ("buys", c.Purchases.Count),
			new XElement ("lastBigBuy",
				new XElement ("description",
					lastBigBuy == null ? null : lastBigBuy.Description),
				new XElement ("price",
					lastBigBuy == null ? 0m : lastBigBuy.Price)
				)
			)
		)
    
