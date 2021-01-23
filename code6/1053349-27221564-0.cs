	static int InsertPlayer(
		int number, string firstName, string lastName, int goals, int assists,
		List<Player> players)
	{
		var player = new Player(number, firstName, lastName, goals, assists);
		var index = players.FindIndex(x => x.Number < number);
		if (index == -1)
		{
			players.Add(player);
			index = players.Count - 1;
		}
		else
		{
			players.Insert(index, player);
		}
		return index;
	}
