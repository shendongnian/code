	void Main()
	{
		string json = @"{
		""id"":   ""658@787.000a35000122"",
		""take"": [{
				""level"":    [0],
				""status"":   [[3, [0]]]
			}]
	}";
		RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
		
	}
	
	public class Take
	{
		[JsonProperty("level")]
		public int[] Level { get; set; }
		
		[JsonProperty("status")]
		public object[][] Status { get; set; }
	}
	
	public class RootObject
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("take")]
		public Take[] Take { get; set; }
	}
