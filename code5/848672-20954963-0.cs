    public class Team {
        [JsonProperty(PropertyName = "id")]
        public int ID {get;set;}
        [JsonProperty(PropertyName = "vendor-id")]
        public int VendorID {get;set;}
        [JsonProperty(PropertyName = "statsinc-id")]
        public int StatsIncID {get;set;}
        [JsonProperty(PropertyName = "team-name")]
        public string TeamName {get;set;}
        [JsonProperty(PropertyName = "team-nickname")]
        public string TeamNickname {get;set;}
        [JsonProperty(PropertyName = "rank")]
        public Rank {get;set;}
    }
