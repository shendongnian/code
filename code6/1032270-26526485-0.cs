    public class MyObject: IXmlSerializable 
    {
        public string Test { get; set; }
        public string Something { get; set; }
    
    	public System.Xml.Schema.XmlSchema GetSchema() { return null; }
    
    	public void ReadXml(System.Xml.XmlReader reader)
    	{		
    		if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "MyObject")
            {			
    			Test = reader["Test"];
    			if (reader.ReadToDescendant("Something"))
                {
    				Something = reader.ReadInnerXml();
    			}
    		}					
    	}
    
    	public void WriteXml(System.Xml.XmlWriter writer)
    	{
    		throw new NotImplementedException();
    	}	
    }
    public static class Program
    {
        public static void Main()
        {	
    		var myObjectXmlString = "<MyObject><Test>Hi hello</Test><Something><Else><With><SubItems count='5'>hello world</SubItems></With></Else></Something></MyObject>";	
    		var myObject =(MyObject) new XmlSerializer(typeof(MyObject)).Deserialize(new StringReader(myObjectXmlString));
    		Console.WriteLine(myObject.Something);
        }
    }
