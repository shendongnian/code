    public class RootObject
    {
        public Dictionary<string, Game<Team>> teamStats { get; set; }
        public Dictionary<string, Game<Player>> playerStats { get; set; }
    }
    public class Game<T>
    {
        public string dateTime { get; set; }
        public string matchId { get; set; }
        public Dictionary<string, T> items { get; set; }
    }
    public class Team
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public int matchVictory { get; set; }
        public int matchDefeat { get; set; }
        public int baronsKilled { get; set; }
        public int dragonsKilled { get; set; }
        public int firstBlood { get; set; }
        public int firstTower { get; set; }
        public int firstInhibitor { get; set; }
        public int towersKilled { get; set; }
    }
    public class Player
    {
        public int playerId { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int minionKills { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int quadraKills { get; set; }
        public int pentaKills { get; set; }
        public string playerName { get; set; }
        public string role { get; set; }
    }
