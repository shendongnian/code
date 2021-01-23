    [Serializable]
    public class EmailNotificationRecipient
    {
        public EmailNotificationRecipient()
        {
    
        }
    
        [XmlElement("recipient")]
        public string Recipient { get; set; }
    }
