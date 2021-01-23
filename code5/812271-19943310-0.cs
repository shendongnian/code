        [XmlRoot("suggest")]
	public class DeliciousSuggest {
		[XmlElement("popular")]
		public string[] Popular { get; set; }
		[XmlElement("recommended")]
		public string[] Recommended { get; set; }
		[XmlElement("network")]
		public string[] Network { get; set; }
	}
