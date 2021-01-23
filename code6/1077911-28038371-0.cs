    public class AddressDetails
    {
        [XmlAttribute("Street")]
        public string StreetName { get; set; }
        [XmlAttribute("CityName")]
        public string City { get; set; }
        public Address address;
        public AddressDetails()
        {
            StreetName = "XYZ";
            City = "Pune";
        }
        public System.Xml.XmlCDataSection MyStringCDATA
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection("load and run");
            }
            set
            { }
        }
    }
