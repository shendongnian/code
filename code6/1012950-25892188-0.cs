    public class CustomIdentity : IIdentity
    {
        private bool _IsAdmin;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
        }
        // other properties
        public CustomIdentity(string Login)
        {
            using(DbContext db = new DbContext())
            {
            User user = db.Users.FirstOrDefault(u => u.Login.Equals(Login, StringComparison.CurrentCultureIgnoreCase));
            _IsAdmin = user.IsAdmin;
            }
        }
    }
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _Identity;
        public CustomPrincipal(string Login)
        {
            _Identity = new CustomIdentity(Login);
        }
        public bool IsInRole(string role)
        {
            if (_Identity != null)
            {
                return role == "Administrator"? _Identity.IsAdmin: false;
            }
            else
            {
                return false;
            }
        }
        //other properties and code
    }
