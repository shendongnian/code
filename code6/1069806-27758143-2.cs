    public class User
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public ICollection<Friend> Friendships { get; set; }
    }
    public class Friend:User
    {
        public int UserID { get; set; }
        [ForeignKey("UserID"), InversePropertyAttribute("Friendships")]
        public User User { get; set; }
        [Required]
        public DateTime FriendshipDate { get; set; }
    }
