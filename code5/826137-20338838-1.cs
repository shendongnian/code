    class Player
    {
        public virtual IList<Match> Matches { get; set; }
    }
    class Match
    {
        public virtual IList<Player> Players { get; set; }
    }
