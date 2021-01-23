    public class FootballTeam 
    { 
        public string Name { get; set; }
        public string Location { get; set; }
        public ManagementCollection Management { get; protected set; } = new ManagementCollection();
        public CoachingCollection CoachingCrew { get; protected set; } = new CoachingCollection();
        public PlayerCollection Players { get; protected set; } = new PlayerCollection();
    }
