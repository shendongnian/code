    	public class School
	{
		[XmlAttribute]
		public int numberOfFields { get; set; }
		
		[XmlArray("Classes")]
		[XmlArrayItem("Class", typeof(Class))]
		public List<Class> Classes { get; set; }
	}
	public class Class
	{
		[XmlAttribute]
		public string name { get; set; }
		[XmlAttribute]
		public string dataType { get; set; }
		[XmlElement("Section")]
		public List<Section> ClassSections { get; set; }
	}
	public class Section
	{
		[XmlAttribute]
		public string value { get; set; }
	}
