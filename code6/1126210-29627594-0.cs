    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public IList<TeamColour> Colours { get; set; }
        public IList<Kit> Kits { get; set; }
        public IList<Player> Players { get; set; }
    }
