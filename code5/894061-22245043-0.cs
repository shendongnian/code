	public class FooClass1
	{
		public int A { get; set; }
		public int B { get; set; }
	}
	public class FooClass2
	{
		public int C { get; set; }
		public int D { get; set; }
	}
	static void Main(string[] args)
	{
		var foo1 = "[{\"a\": 1, \"b\": 2},{\"a\": 2, \"b\": 3}]";
		var foo2 = "[{\"c\": 1, \"d\": 2},{\"c\": 2, \"d\": 3}]";
		var a = Convert<FooClass1>(foo1);
		var b = Convert<FooClass2>(foo2);
	}
	public static List<T> Convert<T>(string jsonString)
	{
		return JsonConvert.DeserializeObject<List<T>>(jsonString);
	}
