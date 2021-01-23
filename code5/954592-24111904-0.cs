    class Team
    {
        public int TeamId { get; set; }
        // ...
        public ICollection<MatchTeam> MatchTeams { get; set; }
    }
    class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
    }
    class MatchTeam
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int Scored { get; set; } // Number of goals/points whatever
        public int RankingScore { get; set; } // 0, 1, or 3
    }
