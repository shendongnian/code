	public class MyModel
	{
		[JsonProperty(PropertyName = "prop1")]
		public int Property1 { get; set; }
		[JsonProperty(PropertyName = "prop2")]
		public int Property2 { get; set; }
		[JsonProperty(PropertyName = "prop3")]
		public int Property3 { get; set; }
		public int Foo { get; set; }
	}
