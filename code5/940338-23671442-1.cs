    namespace Business
    {
        public class User
        {
            private AccountState _state;
            public User()
            {
                _state = AccountState.Active;
            }
    
            public AccountState State
            {
                get { return _state; }
                set { 
                     if (value == AccountState.Active && PasswordExpired)
                        throw new ArgumentException("Can not set active state when the password have expired");
                     _state = value; 
                 }
            }
        }
    }
