    [Serializable()]
    [XmlRoot("Person")]
    public class Person
    {
        XmlElement("FirstName")]
        public string FirstName { get; set; }
	
        XmlElement("LastName")]
        public string LastName { get; set; }
	
        XmlElement("Age")]
        public int Age { get; set; }
	
        [XmlArray("Addresses")]
        [XmlArrayItem("Address", typeof(Address))]
        public List<Address> Addresses { get; set; } 
    }
    [Serializable()]
    public class Address
    {
        [XmlElement("Street")]
        public string Street { get; set; }
	
        [XmlElement("Number")]
        public int Number { get; set; }
	
        [XmlElement("Zipcode")]
        public int Zipcode { get; set; }
	
        [XmlElement("Locality")]
        public string Locality { get; set; }
    }
