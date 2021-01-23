    public class SendGridWebhookRequest
    {
        public string email { get; set; }
        public int timestamp { get; set; }
        public string smtp_id { get; set; }
        [JsonProperty("event")]
        public string MyEvent {get;set;}
    }
