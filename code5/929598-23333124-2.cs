    public class JobOfferModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Acepted { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime JobDate { get; set; }
        [ForeignKey("Id")]
        public int CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<JobOfferModel> JobOffert { get; set; }
    }
