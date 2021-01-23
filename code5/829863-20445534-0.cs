    /// <summary>
    /// game result
    /// </summary>
    public class Result
    {
        public int ResultId { get; set; }
        public int TournamentId { get; set; }
        public int Round { get; set; }
        public DateTime? DatePlayed { get; set; }
        public bool? Completed { get; set; }
        public PlayerTeam Team1 { get; set; }
        public int Team1Score { get; set; }
        public PlayerTeam Team2 { get; set; }
        public int Team2Score { get; set; }
        //double flag
        public bool IsDouble { get; set; }
    }
    /// <summary>
    /// player team, in single game, there is only one player.
    /// </summary>
    public class PlayerTeam
    {
        public int TeamId { get; set; }
        public int Player1Id { get; set; }
        //if in single game, player2Id = 0 or -1, because there is only one player
        public int Player2Id { get; set; }
    }
