    public class CertificateRequest
    {
        [XmlElement("ReturnCode")]
        public int ReturnCode { get; set; }
        [XmlElement("Payload")]
        public Payload Payload { get; set; }
    }
    public class Payload
    {
        [XmlAttribute("content_type")]
        public string ContentType { get; set; }
        [XmlAttribute("embedded")]
        public string Embedded { get; set; }
        [XmlText]
        public string Value { get; set; }
        [XmlIgnore]
        public string DecodedValue
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Value))
                {
                    return string.Empty;
                }
                return System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(Value));
            }
        }
    }
