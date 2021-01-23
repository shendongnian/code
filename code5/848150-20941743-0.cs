    [Table( "UserProfile" )]
    internal class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public int MaxDebt {get; set; }
    }
