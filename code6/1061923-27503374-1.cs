	public class GameCenter
	{
		private Dictionary<string, Lazy<Games>> games = new Dictionary<string, Lazy<Games>>()
		{
			{ "GameWOW", new Lazy<Games>(() => new GameWOW("wow")) },
			{ "GameGW2", new Lazy<Games>(() => new GameGW2("gw2")) },
		};
		
		public Games GetGameFor(string gameType)
		{
			return games.ContainsKey(gameType) ? games[gameType].Value : null;
		}
	}
