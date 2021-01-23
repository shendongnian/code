    class foo
	{
		public string myProp = "foo";
	}
	class bar
	{
		public string myProp = "bar";
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<dynamic> list = new List<dynamic>();
			list.Add(new foo());
			list.Add(new bar());
			foreach (dynamic o in list)
			{
				Console.WriteLine(o.myProp);
			}
		}
	}
