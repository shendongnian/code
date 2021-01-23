    public class Rootobject
    {
        public Resultslist[] resultsList { get; set; }
    }
    public class Resultslist
    {
        public int id { get; set; }
        [JsonProperty("last event")]
        public string lastevent { get; set; }
        [JsonProperty("use id")]
        public string useid { get; set; }
        [JsonProperty("user status")]
        public string userstatus { get; set; }
    }
