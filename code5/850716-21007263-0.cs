    [Serializable, XmlRoot("ThisIsTheRootName")]
    public class Person
    {
      [XmlElement(Order = 1)]
      public string FirstName;
      [XmlElement(Order = 2)]
      public string MiddleName { get; set; }
      [XmlElement(Order = 3)]
      public string LastName;
      [XmlText]
      public string Text;
    }
