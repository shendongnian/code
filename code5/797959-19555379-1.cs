    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<user> Buddies { get; set; }
    }
