	[Serializable]
	public class Theme
	{       
		[XmlAttribute("Title")]
		public string Title { get; set; }
		[XmlAttribute("Name")]
		public string Name { get; set; }
		[XmlAttribute("SpriteCssClass")]
		public string SpriteCssClass { get; set; }
	}
