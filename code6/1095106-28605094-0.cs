    public class Auth
    {
        private static Auth instance;
        private Auth(){}
        public static Auth GetInstance()
        {
            if (instance == null)
                instance = new Auth();
            return instance;
        }
        public string Authorisation { get; set; }
    }
