    class Player
    {
        public virtual IList<Match> Matches { get; set; }
    }
    class Matches
    {
        public virtual IList<Player> Players { get; set; }
    }
