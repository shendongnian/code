	// placeholder for the example
	public class Sample
	{
		public String Name { get; set; }
	}
	// 
	var i = @"{ ""Name"" : ""V\u00E4xj\u00F6"" }";
	var jsonConverter = Newtonsoft.Json.JsonConvert.DeserializeObject(i);
	Console.WriteLine(jsonConverter.ToString());
	//
	var sample = Newtonsoft.Json.JsonConvert.DeserializeObject<Sample>(i);
	Console.WriteLine(sample.Name);
