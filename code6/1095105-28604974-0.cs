    public class Auth
    {
        private static Auth instance = new Auth();
        private Auth(){}
        public static Auth GetInstance()
        {
            if (instance == null)            \\ADDED
               instance = new Auth();
            return instance;
        }
        public string Authorisation { get; set; }
    }
