	public struct test
	{
		public string value;
	}
	static void Main()
	{
		test a;
		a.value = "a";
		test b = a;
		b.value = "b";
		Console.WriteLine("{0} {1}", a.value, b.value);
	}
