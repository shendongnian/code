    class Team : Tuple<string, string>
    {
        public Team(string Id, string Name) : base(Id, Name)
        { }
    }
    static Team[] teams = { 
        new Team("11", "Hurricanes"),
        new Team("2",  "Team abc"),
        new Team("3",  "Vipers"),
        new Team("4",  "Dodgers"),
        new Team("1",  "Frozen Rope"),
    };
