    public class SecureUser
    {
        private readonly User _user;
        public SecureUser(User user)
        {
            _user = user;
        }
        public string UserName
        {
            get { return Encrypt(_user.UserName);
            set { _user.UserNAme = Decrypt(value); }
        }
    }
