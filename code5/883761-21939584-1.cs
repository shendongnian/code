    [JsonConverter(typeof(LeagueUserConverter))]
    public class LeagueUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public int SummonerLevel { get; set; }
        public long RevisionDate { get; set; }
    }
