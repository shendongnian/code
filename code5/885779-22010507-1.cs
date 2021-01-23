    async Task RunDataOneAsymc()
    {
		DataCollectionOne = await GetDataOneAsync();
    }
	// ...
	if (sameCondOne)
	{
		await RunDataOneAsymc();
	}
