    XmlRoot(Namespace = "http://api.vetrf.ru/schema/")]
    public class Enterprise
    {
        [XmlElement(Namespace = "http://api.vetrf.ru/schema/ikar")]
        public Address Address{ get; set; }
        [XmlElement(Namespace = "http://api.vetrf.ru/schema/ikar")]
        public Country Country { get; set; }
       ...
    }
    XmlRoot(Namespace = "http://api.vetrf.ru/schema/ikar")]
    public class Address
    {
     ....    
    }
