    [XmlRoot("Person")]
    public class Person()
    { 
    [XmlElement("FName")]  
    public string Fname { get; set; }
    
    [XmlElement("LName")]   
    public string LName { get; set; }
    
    [XmlElement("Address")]    
    public Address Address;   
    }
    public class Address()
    {
    [XmlAttribute("Type")]
    public string Type { get; set; }
    
    [XmlType]
    public string AddrValue { get; set; }
    }
