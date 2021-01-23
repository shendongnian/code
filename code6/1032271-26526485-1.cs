    public class MyOtherObject 
    {
    	public string Test { get; set; }	
        public XmlElement Something { get; set; }
    	public string SomethingString
    	{
    		get { return Something.OuterXml; }
    	}
    }
    public static class Program
    {
        public static void Main()
        {	
    		var otherObjectXmlString = "<MyOtherObject><Test>Hi hello</Test><Something><Else><With><SubItems count='5'>hello world</SubItems></With></Else></Something></MyOtherObject>";	
    		var otherObject =(MyOtherObject) new XmlSerializer(typeof(MyOtherObject)).Deserialize(new StringReader(otherObjectXmlString));
    		Console.WriteLine(otherObject.SomethingString);				
        }
    }
