    public class Product : Entity
    {
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public int Discount { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public int CategoryId { get; set; }
    	[Required]
    	public virtual Category Category { get; set; }
    
    	public virtual ICollection<Photo> Photos { get; set; }
    	public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
    public class Sale : Entity
    {
    public bool IsActive { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public int ProductId { get; set; } <-- added FK
    	public virtual Product Product { get; set; }
    
        public virtual ICollection<Photo> Photos { get; set; }
    }
