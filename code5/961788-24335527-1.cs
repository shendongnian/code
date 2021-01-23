    public class Account
    {
        private List<UserPermission> _userPersmission;
        public List<UserPermission> UserPermissions
        {
            get { return _userPersmission; }
            set { _userPersmission = value; }
        }
    
        public IEnumerable<User> Users
        {
            get { return _userPersmission.Select(up => up.User); }
        }
    
        public IEnumerable<Permission> Permissions
        {
            get { return _userPersmission.Select(up => up.Permission); }
        }
    }
