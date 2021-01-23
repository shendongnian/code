    public class User : LoganBaseObject<User>
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Biography { get; set; }
        public virtual Role Role { get; set; }
        public bool PasswordReset { get; set; }
        public string PasswordResetKey { get; set; }
        public DateTime ResetExpiry { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
