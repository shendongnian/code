    public class Team
    {
        public string teamName {get; set;}
        public string sportPlayed {get; set;}
        public virtual ICollection<Player> players {get; set;}
    }
