    public class BlockedUser
    {
        [Key, ForeignKey("User"), Column(Order = 1)]
        public int UserId { get; set; }
        [Key, ForeignKey("Contact"), Column(Order = 2)]
        public int ContactId { get; set; }
        [InverseProperty("BlockedUsers")]
        public virtual User User { get; set; }
        [InverseProperty("BlockedContacts")]
        public virtual User Contact { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<BlockedUser> BlockedUsers { get; set; }
        public virtual ICollection<BlockedUser> BlockedContacts { get; set; }
    }
