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
        public IList<Player> Players { get; private set; }
 
        public Team()
        {
            Players = new List<Player>();
        }
    }
    class League
    {
        public string name { get; set; }
        public IList<Team> Teams { get; private set; }
        public League()
        {
            Teams = new List<Team>();
        }
    }
