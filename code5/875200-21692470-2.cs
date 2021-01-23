    public class FootballTeam
    {
        // Football team rosters are generally 53 total players.
        private readonly List<T> _roster = new List<T>(53);
        public IList<T> Roster
        {
            get { return _roster; }
        }
        // Yes. I used LINQ here. This is so I don't have to worry about
        // _roster.Length vs _roster.Count vs anything else.
        public int PlayerCount
        {
            get { return _roster.Count(); }
        }
        // Any additional members you want to expose/wrap.
    }
