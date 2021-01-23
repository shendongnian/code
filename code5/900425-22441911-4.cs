	// example class for demonstrating ToString override
	public class DataHolder
	{
		public string Cod;
		public short Year;
		public int Count;
		// ... functionality ...
		public override string ToString()
		{
			return String.Format("{0}{1}{2}", Cod, Year, Count);
		}
		// if not suitable to override ToString, then define a custom one
		public string Stringify()
		{
			return String.Format("{0}{1}{2}", Cod, Year, Count);
		}
	}
