    public class EmailEvent
    {
        public string Email { get; set; }
        public int TimeStamp { get; set; }
    
        [Newtonsoft.Json.JsonProperty(PropertyName="smtp-id")]
        public string SmtpId { get; set; }
        public string Event { get; set; }
        public string Category { get; set; }
    }
