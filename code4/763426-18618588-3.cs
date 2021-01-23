    [XmlRoot ("Object"), JsonObject]
    public class Root
    {
        [XmlElement, JsonProperty]
        public int Id { get; set; }
        [XmlElement, JsonProperty]
        public string Title { get; set; }
        [XmlElement, JsonProperty]
        public bool Visible { get; set; }
    }
