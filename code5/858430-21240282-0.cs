    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
					
    public class Program
    {
    	[Serializable]
    	[XmlRoot("Objects")]
    	public class MyXml
    	{
    		[XmlElement("Object")]
    		public MyObject[] MyObjects;
    	}
	
	
    	[Serializable]
    	[XmlRoot("Object")]
    	public class MyObject
    	{
    		[XmlAttribute("name")]
    		public string MyName;
    		[XmlElement("Type")]
    		public object MyType;
    	}
	
    	public static void Main()
       	{
    		var data = new MyXml();
    		data.MyObjects = new MyObject[] {new MyObject() { MyName = "Fred"}, new MyObject()};
            using (var stream = new MemoryStream())
            {
                var space = new XmlSerializerNamespaces();
                space.Add("", "");
                var serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(stream, data, space);
    			var text = Encoding.Default.GetString(stream.ToArray());
    			foreach(var line in text.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
				Console.WriteLine(line);
			
    			stream.Seek(0, SeekOrigin.Begin);
    			var test = serializer.Deserialize(stream) as MyXml;
    			Console.WriteLine("\nTest: " + test.MyObjects[0].MyName);
			
    		}
        }
    }
