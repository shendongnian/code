    public class TeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public IEnumerable<PlayerDto> TeamPlayers { get; set; }
    }
    
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
