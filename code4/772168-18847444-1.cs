	var gamesLoaders = new Dictionary<string, Func<List<IGames>>>
	{
		{"MLB", () => dbContext.MLB_Games.ToList()},
		{"NCAAF", () => dbContext.NCAAF_Games.ToList()},
		{"NFL", () => dbContext.NFL_Games.ToList()}
	};
	var sport = "MLB";
	
	if(gamesLoaders.ContainsKey(sport))
		games = gamesLoaders[sport]();
	else
		Logger.Instance.LogMessage("Cannot initialize the requested sport: " + sport);
