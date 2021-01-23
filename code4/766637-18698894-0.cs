    var obj = JsonConvert.DeserializeObject<RootObject>(json);
	public class Data
	{
		public string id { get; set; }
		public object title { get; set; }
		public object description { get; set; }
		public int datetime { get; set; }
		public string type { get; set; }
		public bool animated { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public int size { get; set; }
		public int views { get; set; }
		public int bandwidth { get; set; }
		public bool favorite { get; set; }
		public object nsfw { get; set; }
		public object section { get; set; }
		public string deletehash { get; set; }
		public string link { get; set; }
	}
	public class RootObject
	{
		public Data data { get; set; }
		public bool success { get; set; }
		public int status { get; set; }
	}
