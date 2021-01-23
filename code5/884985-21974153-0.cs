    public class SMTPEvent {
        public string Email { get; set; }
        public long TimeStamp { get; set; }
        public string SmtpId { get; set; }
        public string EventType { get; set; }
    }
    public class SMTPEvents {
        public List<SMTPEvent> Events { get; set; }
    }
