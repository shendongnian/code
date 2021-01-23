     public class Root
     {
        public List<Info> infos{ get; set; }
        public Root()
        {
        }
        public Root(List<Info> infos)
        {
            this.infos = new List<Info>();
            this.infos = infos;
        }
      }
     public class Info
     {
        public Name name { get; set; }
        public int age { get; set; }
        public String sex { get; set; }
        public long id { get; set; }
     }
     public class Name 
    {
        public String first { get; set; }
        public String last { get; set; }
        public String middle { get; set; }
    }
      class XmlConvertor
    {
        public String GetXmlFromObject<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlSerializerNamespaces nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            StringWriter sr = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sr, settings);
            serializer.Serialize(xmlWriter, obj, nameSpace);
             return sr.ToString();
        }
        public T GetObjectFromXml<T>(String xmlString)
        {
            return (T)new XmlSerializer(typeof(T))
                .Deserialize(new StringReader(xmlString));
        }
       
    }
