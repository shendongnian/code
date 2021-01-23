    [JsonObject]
    public class ContainerObj
    {
        [JsonProperty("objects")]
        public ICollection<DrawingObj> Objects { get; set; }
        [JsonProperty("background")]
        public string Background { get; set; }
    }
