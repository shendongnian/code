    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public byte[] Picture { get; set; }
    }
