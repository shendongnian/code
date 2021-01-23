    public class Media // One entity table
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public virtual ICollection<ContractMedia> ContractMedias { get; set; }
    }
    
    public class Contract // Second entity table
    {
        public int Id { get; set; }
    
        public string Code { get; set }
    
        public virtual ICollection<ContractMedia> ContractMedias { get; set; }
    }
    
    public class ContractMedia // Association table implemented as entity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Media")]
        public int MediaId { get; set; }
    
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Contract")]
        public int ContractId { get; set; }
    
        public DateTime StartDate { get; set; }
    
        public DateTime EndDate { get; set; }
    
        public double Price { get; set; }
    
        public virtual Media Media { get; set; }
    
        public virtual Contract Contract { get; set; }
    }
