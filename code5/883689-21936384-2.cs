    public class Param
    {
        public Url Url { get; set; }
        public LoginDetails LoginDetails { get; set; }
    }
    public class Url
    {
        public string LoginPage { get; set; }
        public string AdminPage { get; set; }
        public string ProfilePage { get; set; }
    }
    public class LoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
