	var gamesLoaders = new Dictionary<string, Func<IQueryable<IGames>>>
	{
		{"MLB", () => dbContext.MLB_Games},
		{"NCAAF", () => dbContext.NCAAF_Games},
		{"NFL", () => dbContext.NFL_Games}
	};
	var sport = "MLB";
	
	if(gamesLoaders.ContainsKey(sport))
		games = gamesLoaders[sport]().ToList();
	else
		Logger.Instance.LogMessage("Cannot initialize the requested sport: " + sport);
