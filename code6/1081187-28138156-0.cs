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
        [Required]
        public virtual User User { get; set; }
    }
