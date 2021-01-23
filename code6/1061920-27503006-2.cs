	public class GameCenter {
		public Games GetGameFor(string gameType){
			if (!games.ContainsKey(gameType)){
				switch (gameType) {
					case "GameWOW": games.Add("GameWOW", new GameWOW("wow")); break;
					case "GameGW2": games.Add("GameGW2", new GameGW2("gw2")); break;
					default: return null;
				}
			}
			return games[gameType];
		}
		private Dictionary<string, Games> games = new Dictionary<string, Games>();
	}
