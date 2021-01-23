    public async Task<List<Stock>> Search(string searchQuery, StockLocations location, IngredientFamilies family)
	{
		var query = stockRepo.AsQueryable();
		if (!string.IsNullOrEmpty(searchQuery))
		{
			query = query.Where(x => x.ProductName.Contains(searchQuery) || x.Barcode.StartsWith(searchQuery));
		}
		if (location != StockLocations.All)
		{
			query = query.Where(x => x.Location == location);
		}
		if (family != IngredientFamilies.All)
		{
			query = query.Where(x => x.Family == family);
		}
		return await query.OrderBy(x => x.ExpirationDays).ToListAsync();
	}
