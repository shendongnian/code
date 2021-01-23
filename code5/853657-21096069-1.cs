    [XmlRoot("Request")]
    public class ResponseClass
    {
        [XmlElement("Username")]
        public String UserName { get; set; }
        [XmlElement("Password")]
        public String Password { get; set; }
        [XmlElement("TransactionType")]
        public String Transaction { get; set; }
    }
