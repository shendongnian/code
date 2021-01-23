    public class MerchantAccountBalanceRequest
    {
        [XmlElement("agent")]
        public string Agent { get; set; }
        [XmlElement("agentPin")]
        public string AgentPin { get; set; }
    }
    public class RequestBody
    {
        [XmlElement("accountbalance")]
        public MerchantAccountBalanceRequest BalanceRequest { get; set; }
    }
    [XmlRoot(ElementName = "Envelope")]
    public class RequestEnvelope
    {
        [XmlElement("Body")]
        public RequestBody Body { get; set; }
    }
