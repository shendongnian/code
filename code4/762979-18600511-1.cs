    public class UserResult
    {
        public string Warning { get; set; }
        public IEnumerable<User> Result { get; set; }
    }
    public UserResult GetMappedUsers(/* params */) { }
    public void Whatever()
    {
        var users = GetMappedUsers(/* params */);
        if (!String.IsNullOrEmpty(users.Warning))
            log.Warn(users.Warning);
    }
