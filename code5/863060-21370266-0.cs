    using(var wc = new WebClient())
    {
        string url = "http://musicbrainz.org/ws/2/artist?query=%22metallica%22&fmt=json";
        string json = wc.DownloadString(url);
        var metadata = JsonConvert.DeserializeObject<Metadata>(json);
    }
----
    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty("sort-name")]
        public string sortname { get; set; }
    }
    public class BeginArea
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty("sort-name")]
        public string sortname { get; set; }
    }
    public class LifeSpan
    {
        public string begin { get; set; }
        public object ended { get; set; }
    }
    public class Alias
    {
        [JsonProperty("sort-name")]
        public string sortname { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string type { get; set; }
        public bool? primary { get; set; }
        [JsonProperty("begin-date")]
        public object begindate { get; set; }
        [JsonProperty("end-date")]
        public object enddate { get; set; }
    }
    public class Tag
    {
        public int count { get; set; }
        public string name { get; set; }
    }
    public class Artist
    {
        public string id { get; set; }
        public string type { get; set; }
        public string score { get; set; }
        public string name { get; set; }
  
        [JsonProperty("sort-name")]
        public string sortname { get; set; }
        public string country { get; set; }
        public Area area { get; set; }
        [JsonProperty("begin-area")]
        public BeginArea beginarea { get; set; }
        [JsonProperty("life-span")]
        public LifeSpan lifespan { get; set; }
        public List<Alias> aliases { get; set; }
        public List<Tag> tags { get; set; }
    }
    public class Metadata
    {
        public string created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public List<Artist> artist { get; set; }
    }
