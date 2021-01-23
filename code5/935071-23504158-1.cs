    public UserApplicationLogon : User
    {
        public UserApplicationLogon(string password) : base()
        {
             this.password = password;
        }
        private string password;
        public override bool DoAuthenticate()
        {
             // use password value here
        }
    }
