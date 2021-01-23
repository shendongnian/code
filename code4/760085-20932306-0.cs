        public class Match
    {
        [Key]
        public int MatchID { get; set; }
        public int HostID { get; set; }
        [ForeignKey("HostID")]
        public virtual Club Hosts{ get; set; }
        public int GestID { get; set; }
        [ForeignKey("GestID")]
        public virtual Club Gests{ get; set; }
    }
