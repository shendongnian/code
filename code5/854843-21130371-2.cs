    [XmlRoot(ElementName = "serviceInfo")]
    public class Serviceinfo
    {
        [XmlElement("profiles")]
        public List<Profile> Profiles { get; set; }
    }
    public class Profile
    {
        [XmlElement(ElementName = "profile")]
        public string Name { get; set; }
        [XmlElement(ElementName = "state")]
        public int State { get; set; }
    }
