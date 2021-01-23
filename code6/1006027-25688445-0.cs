    [XmlRoot(ElementName = "Envelope")]
    public class Add_Recipent_response
    {
        public Body Body { get; set; }
    }
    public class Body
    {
        public Result RESULT { get; set; }
    }
    public class Result
    {
        public string SUCCESS { get; set; }
        public string RecipientId { get; set; }
        public string ORGANIZATION_ID { get; set; }
    }
