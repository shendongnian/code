    public class Message
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlElement("Body")]
        public List<string> data { get; set; }
        public Message()
        {
            data = new List<string>();
        }
    }
