    class League
    {
        public string name { get; set; }
        public List<Team> Teams { get; set; }
    }
    class Team
    {
        public Guid TeamGuid { get; set; }
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
    }
    class Player
    {
        public Guid PlayerGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
