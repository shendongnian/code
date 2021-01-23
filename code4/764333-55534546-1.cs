	class JSonModel {
		...
		[JsonProperty("date")]
		public string MyDate { get; set; }
		public string CustomDate {
			get { return MyDate.ToString("DDMMYY"); }
			set { MyDate = DateTime.Parse(value); }
		}
		...
	}
