	public class AnimalCount
	{
		public int Dogs;
		public int Cats;
		public int Fish;
		public int Birds;
	
		private Dictionary<string, Action<int>> rankers
			= new Dictionary<string, Action<int>>()
		{
			{ "dogs", v => Dogs = v },
			{ "cats", v => Cats = v },
			{ "fish", v => Fish = v },
			{ "birds", v => Birds = v },
		};
		
		private Action<string, int> setRank = (t, v) =>
		{
			if (rankers.ContainsKey(t))
			{
				rankers[t](v);
			}
		};
		
		public RankValues(string first, string second, string third, string fourth)
		{
			setRank(first, 10);
			setRank(second, 12);
			setRank(third, 19);
			setRank(fourth, 20);
		}
	}
