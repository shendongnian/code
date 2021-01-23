        static void Main(string[] args)
        {
            var xml ="<?xml version=\"1.0\"?><School><Classes numberOfFields=\"5\"><Class name=\"10\" dataType=\"double\"><Section value=\"A\"/><Section value=\"B\"/><Section value=\"C\"/></Class><Class dataType=\"double\"/><Class dataType=\"double\"/><Class dataType=\"double\"/><Class dataType=\"double\"/></Classes></School>";
            School result;
            var serializer = new XmlSerializer(typeof(School));
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            using (var reader = new XmlNodeReader(xmlDoc))
            {
                result = (School)serializer.Deserialize(reader);
            }
        }
    
    public class School
    {
        [XmlArray("Classes")]
        [XmlArrayItem("Class")]
        public List<Class> Classes { get; set; }
    }
    public class Class
    {
        [XmlElement("Section")]
        public List<Section> ClassSections { get; set; }
    }
    public class Section
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
