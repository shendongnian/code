    public class Team
    { 
        [InverseProperty("Club")]   
        public virtual ICollection<Player> ClubPlayers { get; set; }
        [InverseProperty("National")]
        public virtual ICollection<Player> NationalPlayers { get; set; }
    }
