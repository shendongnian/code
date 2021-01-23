    public class MyObject
   	{
		public List<string> BindToThis1 { get; set; }
		public List<string> BindToThis2 { get; set; }
		public MyObject()
		{
			BindToThis1 = new List<string> { "hello", "world" };
			BindToThis2 = new List<string> { "red", "blue", "green" };
		}
	}
