	public class MyClass
	{
		public int Id;
		public MyClass()
		{
		}
		public static explicit operator MyClass(string s)
		{
			MyClass temp = new MyClass() { Id = Int32.Parse(s) }; 
            // you should handle exceptions when string is not convertible to int
			return temp;
		}
	}
