	var PriceDrops = idxContext.ListingPriceChanges
		.Where(a => a.DateAdded >= LastRunTime && ListingIDsChunk.Contains(a.ListingID))
		.GroupBy(g => g.ListingID)
		.Where(g => g.Count() > 1)
		.Select(g => g.OrderByDescending(a => a.DateAdded).Take(2))
		.Where(g => g.First().ListPrice < g.Last().ListPrice)
		.SelectMany(g => g)
		.ToList();
