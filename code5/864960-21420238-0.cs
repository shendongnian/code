    [XmlRoot("info")]
    public class InfoList
    {
      
      [XmlElement("user")]
      public User[] Users { get ; set ; }
      
      public class User
      {
        [XmlAttribute] public string id       { get; set; }
        [XmlAttribute] public string Name     { get; set; }
        [XmlAttribute] public string Surname  { get; set; }
        [XmlAttribute] public string Computer { get; set; }
      }
      
    }
