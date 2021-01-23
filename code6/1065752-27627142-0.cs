    class Team
    {
        string name = "";
        List<Team> playedAgainst = new List<Team>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Team(string name)
        {
            this.name = name;
        }
        public void AddOpponent(Team opponent)
        {
            this.playedAgainst.Add(opponent);
        }
        public bool hasPlayedAgainst(Team opponent)
        {
            return playedAgainst.Contains(opponent);
        }
        public void Reset()
        {
            playedAgainst.Clear();
        }
        public override bool Equals(object obj)
        {
            if(!(obj is Team))
            return base.Equals(obj);
            Team t = (Team)obj;
            return t.name == name;
        }
        public override string ToString()
        {
            return name;
        }
    }
