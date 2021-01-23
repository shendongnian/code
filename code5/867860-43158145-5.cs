    public class Team
    {
        public Team()
        {
            ClubPlayers = new HashSet<Player>();
            NationalPlayers = new HashSet<Player>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Team name must be at least 2 characters length")]
        public string Name { get; set; }
        [Required]
        public TeamType Type { get; set; }
        [InverseProperty("Club")]
        public virtual ICollection<Player> ClubPlayers { get; set; }
        [InverseProperty("National")]
        public virtual ICollection<Player> NationalPlayers { get; set; }
        public virtual IEnumerable<Player> Players
        {
            get
            {
                return ClubPlayers.Union(NationalPlayers);
            }
        }
        [InverseProperty("HomeTeam")]
        public virtual ICollection<Match> HomeMatches { get; set; }
        [InverseProperty("AwayTeam")]
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual IEnumerable<Match> Matches
        {
            get
            {
                return HomeMatches.Union(AwayMatches);
            }
        }
    }
