    public class Match
    {
        public Guid Id { get; set; }
        public Int32 TeamHomeScore { get; set; }
        public Int32 TeamAwayScore { get; set; }
    
        public Guid TeamHomeId { get; set; } // I want these properties to be foreign keys
        public Guid TeamAwayId { get; set; } //
    
        [ForeginKey("TeamHomeId")]
        public virtual Team TeamHome { get; set; }
        [ForeginKey("TeamAwayId")]
        public virtual Team TeamAway { get; set; }
    }
