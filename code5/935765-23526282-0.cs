    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
    }
