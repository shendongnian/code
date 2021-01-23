    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public string Post(User user)
    {
        // perform actions on user data
        return "success";
    }
