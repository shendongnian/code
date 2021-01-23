    struct FTPServerParams // needs better name
    {
        public readonly string Address;
        public readonly string UserName;
        public readonly string Password;
        public FTPServerParams(string address, string userName, string password)
        {
            Address = address;
            UserName = userName;
            Password = password;
        }
    }
