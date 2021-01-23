	void Main()
	{
		var test = new List<Business>();
		test.Add(new Hotel { Name = "Hilton", Stars = 5 });
		test.Add(new Pool { Name = "Big Splash", Capacity = 500 });
		
		test.Dump();
		
		string json = JsonConvert.SerializeObject(test, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All
		});
		
		json.Dump();
		
		var businesses = JsonConvert.DeserializeObject<List<Business>>(json, new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All
		});
		
		businesses.Dump();
	}
	
	// Define other methods and classes here
	public abstract class Business
	{
		public string Name { get;set; }
	}
	public class Hotel : Business
	{
		public int Stars { get;set; }
	}
	public class Pool : Business
	{
		public int Capacity { get;set;}
	}
