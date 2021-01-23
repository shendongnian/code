    public class LoginModels
    {
        private string _errorMessage;
        // default ctor for serialization
        public LoginModels() 
        {
        }
        
        public LoginModels(string userEmail, string userPassword)
        {
            email = userEmail;
            password = userPassword;
        }
        public string email { get; set; }
        public string password { get; set; }
        public string errorMessage 
        { 
            get 
            { 
                if (string.IsNullOrEmpty(_errorMessage))
                {
                    _errorMessage = GetLoginError();
                }
                return _errorMessage;
            } 
            set { _errorMessage = value; }
        }
        public string GetLoginError()
        {
            if (string.IsNullOrEmpty(email))
            {
                return "email is empty";
            }
            // also no need for "else" here
            return "good";
        }
    }
