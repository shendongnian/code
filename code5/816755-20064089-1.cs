    [XmlRoot(ElementName = "Contact_x0020_Form")]
    public class Root
    {
        [XmlElement("Contacts")]
        public Contacts contacts{get;set;}
    }
    
    
    public class Contacts
    {
      public List<Contact> contacts {get;set;}
    }
    
    public class Contact
    {
    [XmlElement("Id")]
    public int Id {get;set;}
    [XmlElement("Name")]
    public string Name {get;set;}
    [XmlElement("Phone")]
    public string Phone {get;set;}
    }
