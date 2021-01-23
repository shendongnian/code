    [XmlRoot("result")]
    public class Result
    {
        [XmlElement("document")]
        public Document Document { get; set; }
    }
    
    public class Document 
    {
        [XmlElement("response")]
        public Response[] Responses { get; set; }
    
        [XmlAttribute("version")]
        public string Version { get; set; }
    }
    
    public class Response
    {
        [XmlElement("currency")]
        public CurrencyData Currency { get; set; }
    
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
    
    public class CurrencyData
    {
        [XmlElement("code")]
        public string Code { get; set; }
    
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
