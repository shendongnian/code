    [XmlRoot(ElementName = "enclosure")]
    public class Enclosure
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
        [XmlAttribute(AttributeName = "length")]
        public string Length { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
        [XmlElement(ElementName = "contentLength", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string ContentLength { get; set; }
        [XmlElement(ElementName = "infoHash", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string InfoHash { get; set; }
        [XmlElement(ElementName = "magnetURI", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string MagnetURI { get; set; }
        [XmlElement(ElementName = "seeds", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string Seeds { get; set; }
        [XmlElement(ElementName = "peers", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string Peers { get; set; }
        [XmlElement(ElementName = "verified", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string Verified { get; set; }
        [XmlElement(ElementName = "fileName", Namespace = "//kastatic.com/xmlns/0.1/")]
        public string FileName { get; set; }
        [XmlElement(ElementName = "enclosure")]
        public Enclosure Enclosure { get; set; }
    }
    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }
    [XmlRoot(ElementName = "rss")]
    public class KatRss
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "torrent", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Torrent { get; set; }
    }
