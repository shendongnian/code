    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Team name must be at least 2 characters length")]
        public string Name { get; set; }
        [Required]
        public TeamType Type { get; set; }
        //public virtual ICollection<Player> Players { get; set; }
        [InverseProperty("Club")]
        public virtual ICollection<Player> ClubPlayers { get; set; }
        [InverseProperty("National")]
        public virtual ICollection<Player> NationalPlayers { get; set; }
        //public virtual ICollection<Match> Matches { get; set; }
        [InverseProperty("HomeTeam")]
        public virtual ICollection<Match> HomeMatches { get; set; }
        [InverseProperty("AwayTeam")]
        public virtual ICollection<Match> AwayMatches { get; set; }
    }
