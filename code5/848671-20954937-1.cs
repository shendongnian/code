    public class RootObject
    {
        public List<Team> team { get; set; }
    }
    
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("vendor-id")]
        public string VendorId { get; set; }
        [JsonProperty("statsinc-id")]
        public string StatsIncId { get; set; }
        [JsonProperty("team-name")]
        public string TeamName { get; set; }
        [JsonProperty("team-nickname")]
        public string TeamNickname { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
    }
    // this works!
    var obj = JsonConvert.DeserializeObject<RootObject>(data);
    var nicknames = obj.team.Select(x => x.TeamNickname); // "Pistons", "Grizzlies"
