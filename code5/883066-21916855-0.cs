    [XmlRoot("ArrayOfProfile")]
    [XmlType("Profile")]
    public class Profile
    {
        [XmlAttribute("ProfileID")]
        public string ProfileID { get; set; }
    
        [XmlAttribute("LastUpdated")]
        public DateTime LastUpdatedDate { get; set; }
    
        [XmlArray("Job")]
        public List<Job> Jobs { get; set; }
    }
