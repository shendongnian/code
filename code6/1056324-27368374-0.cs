    [DataContract(Name = "person", Namespace = "")]
    public class PersonnResponse:IXmlSerializable
    {
       ...
    
    	 public XmlSchema GetSchema()
        {
            return null;
        }
    	
    	
    	public void ReadXml (XmlReader reader)
        {
       		var xd = XDocument.Load(reader);
    		firstName = xd.Descendants().First (x => x.Name.LocalName == "firstName" ).Value;
    		lastName = xd.Descendants().First (x => x.Name.LocalName == "lastName" ).Value;
        	userId = xd.Descendants().First (x => x.Name.LocalName == "userId" ).Value;
    	}
    	
    	public void WriteXml(XmlWriter writer){
    	
    		
    		writer.WriteElementString("userId", userId);
    		writer.WriteElementString("firstName", firstName);
    		writer.WriteElementString("lastName", lastName);
    	
    	}
    }
    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            t.Serialize();
        }
    
        private void Serialize()
        {
            // Create an instance of the class, and an 
            // instance of the XmlSerializer to serialize it.
            var pers = new PersonnResponse(){ firstName="Call Me", lastName="Heisenberg", userId="Id"};
            XmlSerializer ser = new XmlSerializer(typeof(PersonnResponse));
    		
    		StringWriter tw = new StringWriter();
    		ser.Serialize(tw,pers);
    		Console.WriteLine(tw.ToString());
    		
    		//Deserialize from XML string
    		var sw = new StringReader(tw.ToString());
    		var NewPerson = ser.Deserialize(sw);
    		
        }
    }
