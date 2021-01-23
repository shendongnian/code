    [Table("user")]
    public class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public virtual List<user> Buddies { get; set; }
    }
