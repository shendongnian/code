    public class StatRankedJoueur
    {
        public double ModifyDate { get; set; }
        public int SummonerId { get; set; }
        public IEnumerable<Champion> Champions { get; set; }
    }
    public class Champion
    {
        public int id { get; set;}
        public Stats stats { get; set;}
    }
    public class Stats
    {
        public double totalDeathsPerSession { get; set; }
        public double totalSessionsPlayed { get; set; }
        public double totalDamageTaken { get; set; }
        public double totalQuadraKills { get; set; }
        public double totalTripleKills { get; set; },
        public double totalMinionKills { get; set; }
        public double maxChampionsKilled { get; set; }
        public double totalDoubleKills { get; set; }
        public double totalPhysicalDamageDealt { get; set; }
        public double totalChampionKills { get; set; }
        public double totalAssists { get; set; }
        public double mostChampionKillsPerSession { get; set; }
        public double totalDamageDealt { get; set; }
        public double totalFirstBlood { get; set; }
        public double totalSessionsLost { get; set; }
        public double totalSessionsWon { get; set; }
        public double totalMagicDamageDealt { get; set; }
        public double totalGoldEarned { get; set; }
        public double totalPentaKills { get; set; }
        public double totalTurretsKilled { get; set; }
        public double mostSpellsCast { get; set; }
        public double maxNumDeaths { get; set; }
        public double totalUnrealKills { get; set; }
    }
