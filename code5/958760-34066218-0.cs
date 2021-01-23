	void Main()
	{	
		var o = JsonConvert.DeserializeObject<Test>("{\"Property\":\"Instance\"}");
		Debug.Assert(o.Property == "Instance",
            "Property value not set when deserializing.");
	}
	
	public class Test
	{
		public string Property { get; set; }
	
		private Test()
		{
		}
	
		public Test(string propertyValue)
		{
			Property = propertyValue;
		}
	}
