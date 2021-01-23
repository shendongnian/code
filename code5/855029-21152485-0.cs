    public class Person
    {
        public string Name { get; set; }
        public InnerXml Address { get; set; }
    }
    
    public class InnerXml : IXmlSerializable
    {
        public string Content { get; set; }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Content = reader.ReadInnerXml();
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (Content != null)
            {
                writer.WriteRaw(Content);
            }
        }
    }
    
    using (var testXmlReader = new StringReader(testXml))
    {
        var serializer = new XmlSerializer(typeof(Person));
        var person = (Person)serializer.Deserialize(testXmlReader);
    
        Console.WriteLine(person.Address.Content); //outputs <Hotel>Merriot</Hotel>
    }
