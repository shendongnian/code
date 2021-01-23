	var customersByCountry = db.Customers
		.GroupBy(c => c.CountryID);
		.Select(g => new { CountryID = g.Key, Count = g.Count() });
	var ranks = customersByCountry
		.Select(c => new 
			{ 
				c.CountryID, 
				c.Count, 
				Rank = customersByCountry.Count(c2 => c2.Count > c.Count) + 1
			});
		
