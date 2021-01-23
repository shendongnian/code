	public class ValuesAttribute : Attribute
	{
		public int V1 { get; private set; }
		public int V2 { get; private set; }
		
		public ValuesAttribute(int v1, int v2)
		{
			V1 = v1;
			V2 = v2;
		}
	}
	
	public enum ValuesCase
	{
		[Values(5, 6)]
		Five,
		[Values(30, 25)]
		Six
	}
	
	public void DoStuff(ValuesCase valuesCase)
	{
		// There are several ways to get an attribute value of an enum, but I like this one
		ValuesAttribute values = valuesCase
			.GetType()
			.GetTypeInfo()
			.GetDeclaredField(valuesCase.ToString())
			.GetCustomAttribute<ValuesAttribute>();
		
		if(values != null)
		{
			// Assign your variables or do whatever else you want here
			Console.WriteLine(string.Join(", ", valuesCase.ToString(), values.V1, values.V2));
		}
	}
		
	void Main()
	{
		DoStuff(ValuesCase.Five);
		DoStuff(ValuesCase.Six);
	}
