    public class User
    {
        [Key,ForeignKey("Profile")]
        public int Id { get; set; }
        public Profile Profile { get; set; }
    }
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public virtual User ProfileOwner { get; set; }
        public virtual ICollection<StandingData> DataCollection { get; set; } 
    }
    public class StandingData
    {
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
