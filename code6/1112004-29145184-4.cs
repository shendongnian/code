    using (var db = new MyContext())
    {
    	var anonymousMarkets = db.Markets
            .Where(o => o.MarketId == marketId)
    		.Select(o => new        // project as an anonymous object
    		{
    			o.MarketId,
    			o.Description,
    			Dealers = o.Dealers.Where(d => d.DealerId == dealerId)
    		})
    		.ToList();
    	Console.WriteLine("Check if all dealers don't have market: " +
    	    anonymousMarkets.SelectMany(o => o.Dealers).All(o => o.Market == null));
        Console.WriteLine("All dealers in the markets: " + 
            anonymousMarkets.SelectMany(o => o.Dealers).Count());
    }
