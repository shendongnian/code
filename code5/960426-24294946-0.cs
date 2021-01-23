    [XmlRoot("EmailAddresses")]
    public class EmailAddress
    {
        [XmlElement("Email")]
        public List<string> Emails { get; set; }
    }
