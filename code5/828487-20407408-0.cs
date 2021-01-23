    public class AddressingHeader : SoapHeader
    {
        public AddressingHeader()
            : base() { }
    
        [XmlElement("Action")]
        public string Action
        {
            get; set;
        }
    }
