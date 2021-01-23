    class DBContext
    {
        private int _loginAttempts = 0; // I assume private to keep from exposing it for security
        public int validateUser(string username, string userPassword)
        {
            // some code to test userPassword and increase or reset counter as needed
        }
        // more methods etc.
    }
        
