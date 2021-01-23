    public class User : EntityBase
    {
        public virtual string Username { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Salt { get; set; }
        public virtual Role Role { get; set; } //CHANGED HERE
        public virtual string Token { get; set; }
        public virtual DateTime TokenStamp { get; set; }
    }
