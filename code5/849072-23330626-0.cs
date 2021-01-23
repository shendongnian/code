	using System.Collections.Generic;
	public class AnimalCount
	{
		public int Dogs { get { return animals["dogs"]; } }
		public int Cats { get { return animals["cats"]; } }
		public int Fish { get { return animals["fish"]; } }
		public int Birds { get { return animals["birds"]; } }
		
		private Dictionary<string, int> animals = new Dictionary<string, int>();
		
		public void RankValues(string first, string second, string third, string fourth)
		{
			animals[first] = 10;
			animals[second] = 12;
			animals[third] = 19;
			animals[fourth] = 20;
		}
	}
