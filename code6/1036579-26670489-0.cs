	public class Item
	{
		private readonly LimitedString _reality = new LimitedString("Real", "Imaginary", "Based on reality");
		public string Reality
		{
			get { return _reality.Value; }
			set { _reality.Value = value; }
		}
		private readonly LimitedString _colour = new LimitedString("Other", "Blue", "Red", "Green");
		public string Colour
		{
			get { return _colour.Value; }
			set { _colour.Value = value; }
		}
	}
