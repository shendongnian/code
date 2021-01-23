	public class Card
	{
		private Card()
		{
		}
		public class Manager
		{
			public Card Create()
			{
				return new Card();
			}
		}
	}
