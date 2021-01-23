    public class Program
        {
            public static void Main(string[] args)
            {
                var products = new MyObjects()
                {
                    new MyObject() {Id = 1, Name = "Dell"},
                    new MyObject() {Id = 2, Name = "Sony"},
                    new MyObject() {Id = 3, Name = "HP"}
                };
    
                var serializeObject = SerializeObject<MyObjects>(products);
                Console.WriteLine(serializeObject);
                Console.ReadLine();
            }
    
            public static string SerializeObject<T>(Object data)
            {
                string result;
                try
                {
                    var xmlData = new MemoryStream();
                    var xmlEncodedData = new XmlTextWriter(xmlData, Encoding.UTF8);
                    var serial = new XmlSerializer(typeof(T));
                    serial.Serialize(xmlEncodedData, data);
                    xmlData.Position = 0;
    
                    var reader = new StreamReader(xmlData);
    
                    result = reader.ReadToEnd();
    
                }
                catch (Exception)
                {
                    return string.Format("Error in return data");
                }
    
                return result;
            }
        }
    
        [XmlRoot("Response")]
        [Serializable]
        public class MyObjects : List<MyObject>, IXmlSerializable
        {
            
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }
    
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("MyObjects");
                foreach (var myObject in this)
                {
                    writer.WriteStartElement("MyObject");
                    new XmlSerializer(typeof(MyObject)).Serialize(writer, myObject);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    
        public class MyObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
 
           }
    }
