    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserDetails Details { get; set; }
    }
