    [Serializable]
    public class Model
    {
        [XmlElement("cdn_streaming_uri")]
        public string CdnStreamingUri { get; set; }
    
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("cdn_ios_uri")]
        public string CdnIosUri { get; set; }
    
        [XmlElement("cdn_ssl_uri")]
        public string CdnSslUri { get; set; }
    
        [XmlElement("cdn_enabled")]
        public bool CdnEnabled { get; set; }
    
        [XmlElement("ttl")]
        public int Ttl { get; set; }
    
        [XmlElement("log_retention")]
        public bool LogRetention { get; set; }
    
        [XmlElement("cdn_uri")]
        public string CdnUri { get; set; }
    }
