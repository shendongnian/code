    public class Model
    {
        [DataMember(Name = "cdn_streaming_uri")]
        public string CdnStreamingUri { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "cdn_ios_uri")]
        public string CdnIosUri { get; set; }
        [DataMember(Name = "cdn_ssl_uri")]
        public string CdnSslUri { get; set; }
        [DataMember(Name = "cdn_enabled")]
        public bool CdnEnabled { get; set; }
        [DataMember(Name = "ttl")]
        public int Ttl { get; set; }
        [DataMember(Name = "log_retention")]
        public bool LogRetention { get; set; }
        [DataMember(Name = "cdn_uri")]
        public string CdnUri { get; set; }
    }
