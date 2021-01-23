    public class User
    {
        public User()
        {
            Users = new List<User>();
            Friends = new List<User>();
            ChatRooms = new List<ChatRoom>();
        }
    
        [Key]
        public int ID { get; set; }
    
        [Required, MinLength(4), MaxLength(20)]
        public string Name { get; set; }
    
        [Required, MinLength(8), MaxLength(40)]
        public string Email { get; set; }
    
        [Required, MinLength(8), MaxLength(15)]
        public string Password { get; set; }
    
        [Required]
        public DateTime JoinedOn { get; set; }
    
        [InverseProperty("Friends")]
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> Friends { get; set; }
    
        [InverseProperty("Participants")]
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
    }
