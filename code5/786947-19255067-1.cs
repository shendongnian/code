    class League
    {
        public Team[] Teams { get; set; }
    }
    class Team
    {
        public League League { get; set; }
        public Player[] Players { get; set; }
    }
    
    class Player
    {
        public Team Team { get; set; }
    }
