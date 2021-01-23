    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Password { get; set; }
        public bool Locked { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
    public class Customer
    {
        [Key]
        [Column("Id", TypeName = "nvarchar")]
        [StringLength(20)]
        public string Id { get; set; }   //  nvarchar    20
        [Required]
        public string GivenName { get; set; }   //  nvarchar    100
        [Required]
        public string Surname { get; set; }   //  nvarchar    100
        public virtual  ICollection<User> Users { get; set; }
    }
