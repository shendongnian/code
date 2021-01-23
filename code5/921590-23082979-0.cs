    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public UserDetails Details { get; set; }
    }
