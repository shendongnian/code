    public class UserProfilePermissions
    {
        public UserProfile User { get; set; }
        public Permission Permission { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class Permission
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Group { get; set; }
    }
