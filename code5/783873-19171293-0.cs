    public class dtvTwitter
    {
        public tweets tweets{get;set;}
    }
    public class tweets
    {
        [XmlElement("RcsTweet")]
        public List<RcsTweet> RcsTweets { get; set; }
    }
    public class RcsTweet
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Tweet { get; set; }
        [XmlAttribute]
        public string Handle { get; set; }
    }
