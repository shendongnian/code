    [XmlRoot("messages", Namespace = NS.Common)]
    public partial class messages
    {
        [XmlElementAttribute("message", Namespace = "")]
        public List<Message> message { get; set;}
    }
    
    public partial class Message
    {
        [XmlElement("messageCode", Namespace = "")]
        public MessageCode messageCode { get; set; }
    
        [XmlElement("message", Namespace = "")]
        public string message { get; set; }
    }
    
    [Serializable]
    [XmlType(Namespace = "")]
    public enum MessageCode
    {
        ERROR_DESCRIPTION,
        RESOURCE_CREATED
    }
