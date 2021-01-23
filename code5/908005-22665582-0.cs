    [XmlRoot(ElementName = "person", Namespace = "somenamespace")]
    public class Person {
      [XmlElement(ElementName = "firstName", Namespace = "")]
      public string fistName { get; set; }
      [XmlElement(ElementName = "lastName", Namespace = "")]
      public string lastName { get; set; }
    }    
