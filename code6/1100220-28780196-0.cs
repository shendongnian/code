    [XmlRoot(ElementName = "response")]
    public class Response 
    {
          public List<MyObject> MyObjects {get;set;}
    }
    [XmlElement("myObject")]
    public class MyObject { ... }
