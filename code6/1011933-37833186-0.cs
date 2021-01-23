	[MyAttribute(MySimpleParameter: "Foo")]
	public class MyObject
	{
	}
	public class MyAttribute : Attribute
	{
		public string MySimpleProperty { get; set; }
		public MyPropertyClass MyComplexProperty { get; set; }
		
		public MethodAttribute(string MySimpleParameter, MyPropertyClass MyComplexParameter = null)
		{
			MySimpleProperty = MySimpleParameter;
			MyComplexProperty = MyComplexParameter;
		}
	}
	public class MyPropertyClass
	{
		public string Name { get; set; }
		public string Method { get; set; }
	}
