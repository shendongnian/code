    [XmlRoot(ElementName = "Class1"), XmlType("Class1")]
    public class Class1
    {
      public Class1()
      {
         ServiceList = new List<service>();
      }
      [XmlElement(ElementName = "ServiceList")
      public List<service> ServiceList { get; set; }
    }
   
    [XmlRoot(ElementName = "Service"), XmlType("Service")]
    public class service
    {
       [XmlElement(ElementName = "ServiceName")
       public string ServiceName { get; set; }
   
       [XmlElement(ElementName = "Symbol")
       public string Symbol { get; set; }
    }
