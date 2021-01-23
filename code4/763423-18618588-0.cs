    [XmlRoot ("Object"), JsonObject]
    public class Root
    {
        [XmlAttribute, JsonProperty]
        public int Id { get; set; }
        [XmlAttribute, JsonProperty]
        public string Title { get; set; }
        [XmlAttribute, JsonProperty]
        public bool Visible { get; set; }
    }
