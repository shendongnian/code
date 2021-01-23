    public class Creds
    {
        public string Username { get; set; }
        public string Password { get; set; }
    
        public Creds(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }
    }
