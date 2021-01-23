    var connection = new SQLiteAsyncConnection(() => sqlite.GetConnectionWithLock());
	await connection.CreateTablesAsync<Ingredient, Stock>();
	IRepository<Stock> stockRepo = new Repository<Stock>(connection);
    IRepository<Ingredient> ingredientRepo = new Repository<Ingredient>(connection);
    var stock1 = new Stock { 
		IngredientId = 1,
		DaysToExpire = 3,
		EntryDate = DateTime.Now,
		Location = StockLocations.Fridge,
		MeasureUnit = MeasureUnits.Liter,
		Price = 5.50m,
		ProductName = "Leche Auchan",
		Quantity = 3,
		Picture = "test.jpg",
		Family = IngredientFamilies.Dairy
	};
    var stockId = await stockRepo.Insert(stock1);
    var all = await stockRepo.Get();
	var single = await stockRepo.Get(72);
	var search = await stockRepo.Get(x => x.ProductName.StartsWith("something"));
	var orderedSearch = await stockRepo.Get(predicate: x => x.DaysToExpire < 4, orderBy: x => x.EntryDate);
