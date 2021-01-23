	public class Card
	{
		public string Name { get; private set; }
		
		public IList<string> PersonsHoldingThisCard { get; private set; }
		
		public Card(string name)
		{
			Name = name;
			PersonsHoldingThisCard = new List<string>();
		}
	}
