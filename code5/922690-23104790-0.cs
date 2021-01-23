    [XmlRoot("TEST")]
    public class Test
    {
         [XmlElement(Name = "DEMO")]
         public Demo Demo
         {
              get;
              set;
         }
    } 
    public class Demo
    {
        [XmlElement("CONTENTINFO")]
        public ContentInfo ContentInfo
        {
           get;
           set;
        }
    }
    public class ContentInfo
    {
       [XmlAttribute(Name = "name")]
       public string Name
       {
          get;
          set;
       }
       [XmlAttribute(Name = "receiver")]
       public string Reciever
       {
          get;
          set;
       }
    }
    XmlSerializer serializer = new XmlSerializer(typeof(Test));
    serializer.Serialize(....);
    Test testInstance = serializer.Deserialize(....);
    ... etc.
