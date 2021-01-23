    public class Security
    {
        public int Id { get; set; }
        public string SecMsg { get; set; }
        public string Trace { get; set; }
        public int ErrorCode { get; set; }
        public int UserId { get; set; } //This is just to tell EF to name the FK column as UserId rather than UserProfile_UserId
        public virtual UserProfile UserProfile { get; set; } //This is good enough to tell EF that there is a relationship
    }
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Security> Securities { get; set; } //Good enough to indicate the relationship
    }
