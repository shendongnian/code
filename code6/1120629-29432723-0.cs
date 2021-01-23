    public class MyObject
	{
		[JsonProperty("@size")]
		public string size { get; set; }
		public string text { get; set; }
		public int Id { get; set; }
	}
    var result = JsonConvert.DeserializeObject<MyObject>(json);
