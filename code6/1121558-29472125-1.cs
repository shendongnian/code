    public abstract class RequestBase
    {
    }
    public class SomeOtherRequest : RequestBase
    {
        [XmlElementAttribute("example")]
        public string Example { get; set; }
    }
    public class MerchantAccountBalanceRequest : RequestBase
    {
        [XmlElement("agent")]
        public string Agent { get; set; }
        [XmlElement("agentPin")]
        public string AgentPin { get; set; }
    }
    public class RequestBody
    {
        [XmlElement(ElementName = "accountbalance", Type = typeof(MerchantAccountBalanceRequest))]
        [XmlElement(ElementName = "somethingelse", Type = typeof(SomeOtherRequest))]
        public RequestBase Request { get; set; }
    }
