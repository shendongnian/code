    public class PlayerRetriever<T>
		where T : IPlayer<T>
	{
		public static IPlayer<T> Retrieve(string SitePath)
		{
			if (SitePath == "Home") { return new Player1(); }
			else { return new AnotherPlayer(); }
		}
	}
	interface IPlayer<T>
	{
		void RunPlayer();
		List<T> RetrievePlayersByMovie(string movie);
	}
