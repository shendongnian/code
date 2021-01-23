    public class InboundEmailInputModel
    {
        public string Headers { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<string> Cc { get; set; }
        public string Subject { get; set; }
        public string Dkim { get; set; }
        public string Spf { get; set; }
        public InboundEmailEnvelopeInputModel Envelope { get; set; }
        public InboundEmailCharsetsInputModel Charsets { get; set; }
        public float SpamScore { get; set; }
        public string SpamReport { get; set; }
        public int Attachments { get; set; }
        public dynamic AttachmentInfo { get; set; }
        public HttpFileCollectionBase AttachmentFiles { get; set; }
        public string SenderIp { get; set; }
    }
    public class InboundEmailEnvelopeInputModel
    {
        public string From { get; set; }
        public List<string> To { get; set; }
    }
    public class InboundEmailCharsetsInputModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Html { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
