    [XmlRoot("messages", Namespace = NS.Common)]
    public partial class messages
    {
        [XmlElementAttribute("message", Namespace = String.Empty)]
        public List<Message> message { get; set;}
    }
    
    public partial class Message
    {
        [XmlElement("messageCode", Namespace = String.Empty)]
        public MessageCode messageCode { get; set; }
    
        [XmlElement("message", Namespace = String.Empty)]
        public string message { get; set; }
    }
    
    [Serializable]
    [XmlType(Namespace = String.Empty)]
    public enum MessageCode
    {
        ERROR_DESCRIPTION,
        RESOURCE_CREATED
    }
