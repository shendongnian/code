    public class Partner
    {
        [Key]
        [ForeignKey("User")]
        public virtual int Id { get; set; }
    
        public User User { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
    public class Department
    {
        [Key]
        [ForeignKey("User")]
        public virtual int Id { get; set; }
        public User User { get; set; }
        public string Prefix { get; set; }
    }
