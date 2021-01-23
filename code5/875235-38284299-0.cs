    public class FootballTeam 
    { 
        public string Name { get; set; }
        public string Location { get; set; }
        public ManagementList Management { get; protected set; } = new ManagementList();
        public CoachingList CoachingCrew { get; protected set; } = new CoachingList();
        public PlayerList Players { get; protected set; } = new PlayerList();
    }
