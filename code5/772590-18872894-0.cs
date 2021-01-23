    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
