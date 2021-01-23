    class Player
    {
        public Guid PlayerGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Team
    {
        public Guid TeamGuid { get; set; }
        public string TeamName { get; set; }
        public Player[] Players { get; set; }
    }
    class League
    {
        public string name { get; set; }
        public Team[] Teams { get; set; }
    }
