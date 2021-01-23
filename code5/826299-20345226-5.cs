		public class NVPair {
			public string acl { get; set; }
			public string bucket { get; set; }
			[JsonProperty("Content-Type")]
			public string ContentType { get; set; }
			public string success_action_status { get; set; }
			public string key { get; set; }
			...
		}
		public class ResponseVM
		{
			public DateTime Expiration { get; set; }
			public List<NVPair> Conditions { get; set; }
		}
