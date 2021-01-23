	public class Movies
	{
		// define the custom attribute
		[XmlAttribute(AttributeName="CustomAttribute")]
		public String Custom { get; set; }
		// define the collection description
		[XmlArray(ElementName="ArrayOfMovie")]
		public List<Movie> Items { get; set; }
	}
	
	public class Movie
	{
		public string VideoId { get; set; }
		public string Title { get; set; }
	}
