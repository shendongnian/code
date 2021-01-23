    public UserWindowsLogon : User
    {
        public string windowsDomain;
        public string password;
        public override bool DoAuthenticate()
        {
             // Check and use windowsDomain/password values here
        }
    }
