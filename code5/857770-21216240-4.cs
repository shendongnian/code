	// helper classes describing the library object (for the JSON deserialization)
	public class Library
	{
		public String Name { get; set; }
		public Rules[] Rules { get; set; }
	}
	public class Rules
	{
		public String Action { get; set; }
		public Os Os { get; set; }
	}
	public class Os
	{
		public String Name { get; set; }
		public String Version { get; set; }
	}
