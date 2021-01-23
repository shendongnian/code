	public class test
	{
		public string value;
	}
	static void Main()
	{
		test a = new test(); // Note the 'new' keyword to create a reference type instance
		a.value = "a";
		test b = a;
		b.value = "b";
		Console.WriteLine("{0} {1}", a.value, b.value);
	}
