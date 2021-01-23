    public class User
    {
        [PrimaryKey, AutoIncrement, Alias("Id")]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Enabled { get; set; }
    }
