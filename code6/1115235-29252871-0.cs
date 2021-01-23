    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://vouchers.example.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://vouchers.example.com", IsNullable = false)]
    public class redeemVoucherResponse
    {
        public redeemVoucherResponseReturn @return { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://vouchers.example.com")]
    public class redeemVoucherResponseReturn
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://util.vouchers.example.com/xsd")]
        public string status { get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://util.vouchers.example.com/xsd")]
        public byte statusCode { get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://util.vouchers.example.com/xsd")]
        public string statusMessage { get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://util.vouchers.example.com/xsd", IsNullable = true)]
        public object redeemData { get; set; }
    }
