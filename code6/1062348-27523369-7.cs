	[XmlRootAttribute("ls")]
	public class Request<T>
	{
		[XmlAttribute("ver")]
		public string Version { get; set; }
		[XmlElement(ElementName = "ChildClass")]
		public T Data { get; set; }
	}
	[XmlRoot("ChildClass")]
	public class class2
	{
		[XmlElement("login")]
		public string Property1 { get; set; }
	}
