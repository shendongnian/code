    public class EmailMessage
    {
        public EmailAddress To { get; set; }
    
        public EmailAddress From { get; set; }
    
        public string Subject { get; set; }
    
        public string Body { get; set; }
    
        public EmailAttachment Attachment { get; set; }
        public struct EmailAttachment
        {
            public string Name { get; set; }
    
            public string Bas64 { get; set; }
        }
    }
