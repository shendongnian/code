    public class Request
    {
        [XmlElement("token")]
        public string token { get; set; }
        [XmlElement("userId")]
        public int userId { get; set; }
        [XmlElement("accountId")]
        public int accountId { get; set; }
        [XmlElement("method")]
        public Method method { get; set; }
    }
    public class Method
    {
        [XmlElement("methodName")]
        public string methodName { get; set; }
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
    }
