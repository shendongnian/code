    void Login(string user, string password);//Or return a bool(redundant though)
    class LoginFailedException : ApplicationException
    {
        public LoginFailReason Reason {get; private set;}
        public LoginFailedException(LoginFailReason reason)
        {
           this.Reason = reason;
        }
    }
    
    enum LoginFailReason
    {
        UnknownUser,
        WrongPassword
    }
