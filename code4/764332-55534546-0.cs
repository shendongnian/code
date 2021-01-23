	class JSonModel {
		...
		private DateTime myDate;
		[JsonProperty("date")]
		public string CustomDate {
			get { return myDate.ToString("DDMMYY"); }
			set { myDate = DateTime.Parse(value); }
		}
		...
	}
