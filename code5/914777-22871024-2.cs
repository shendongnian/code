    	public class School
	{
	
		[XmlElement("Classes")]
		public List<ArrayClass> Classes { get; set; }
	}
	public class ArrayClass
	{
		[XmlAttribute]
		public int numberOfFields { get; set; }
		[XmlElement("Class")]
		public List<Class> Class { get; set; }
		
	} 
