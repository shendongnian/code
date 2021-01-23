	using System.Collections.Generic;
	public enum Animals
	{
		Dogs, Cats, Fish, Birds
	}
	public class AnimalCount
	{
		public int Dogs { get { return animals[Animals.Dogs]; } }
		public int Cats { get { return animals[Animals.Cats]; } }
		public int Fish { get { return animals[Animals.Fish]; } }
		public int Birds { get { return animals[Animals.Birds]; } }
		
		private Dictionary<Animals, int> animals = new Dictionary<Animals, int>();
		
		public void RankValues(Animals first, Animals second, Animals third, Animals fourth)
		{
			animals[first] = 10;
			animals[second] = 12;
			animals[third] = 19;
			animals[fourth] = 20;
		}
	}
