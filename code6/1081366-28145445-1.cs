    public class GameStats
    {
        public GameType Type { get; set; }
        public string StatType { get; set; }
        public string StatValue { get; set; }
        public GameStats(GameType gameType, string statType, string statValue)
        {
            this.Type = gameType;
            this.StatType = statType;
            this.StatValue = statValue;
        }
    }
