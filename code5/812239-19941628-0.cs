    public class User 
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email 
        {
            get { return this.Username; }
            set { this.Username = value; }
        }
    }
