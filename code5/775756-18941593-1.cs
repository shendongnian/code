    public class PlayerModel
    {
        [Key]
        public int PlayerID { get; set; }
        [InverseProperty("Player")]
        public ICollection<SeasonStats> SeasonStats { get; set; }
    
        public PlayerModel()
        {
            this.SeasonStats = new List<SeasonStats>();
            //Add season stats for each year
            this.SeasonStats.Add(new SeasonStats(){Year = 2012};);
            this.SeasonStats.Add(new SeasonStats(){Year = 2011};);
            this.SeasonStats.Add(new SeasonStats(){Year = 2010};);
        }
    }
    
    public class SeasonStats
    {
        [Key]
        public int Year { get; set;}
        public int Goals { get; set; }
        public int Assists { get; set; }
        [ForeignKey("PlayerID")]
        public Player Player{get; set; }
        [Required]
        public int PlayerID {get; set; }
    }
