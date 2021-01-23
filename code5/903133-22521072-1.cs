    [Serializable]
    public class EpisodeData
    {
        [XmlArray("Episodes")]
        [XmlArrayItem(ElementName = "Episode")]
        List<Episode> Episodes { get; set; }
    }
    [Serializable]
    public class Episode
    {
        [XmlAttribute]
        public string Description { get; set; }
        [XmlAttribute]
        public string Author { get; set; }
        [XmlAttribute]
        public string DownloadLink { get; set; }
    
        ...
    }
