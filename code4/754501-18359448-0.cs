    public class School 
    {
    	[XmlAttribute] //XML Serializer attribute
    	[MaxLength(30)] // CodeFirst Data Annotations
    	public string Name { get; set;}
    	[XmlArray]
    	public List<string> Students { get; set; } 
    }
