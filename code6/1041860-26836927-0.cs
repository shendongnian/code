    public class SomeFile
	{
		public Header Header { get; set; }
		public Body Body { get; set; }
		
	}
	public class Header
	{
		internal Header()
		{
		}
		public DateTime CreateDate { get; set; }
	}
	public class Body
	{
		internal Body()
		{
		}
		public string Hash { get; private set; }
	}
