    public class ProductAttribute
    {
        [Key]
        [Required]
        public string FieldName { get; set; }
    
        public string FieldValue { get; set; }
    
        [Key]
        [ForeignKey("Item"), Column(Order = 1)]
        public string ItemNo { get; set; }
    
        [Key]
        [ForeignKey("Item"), Column(Order = 2)]
        public string VariantCode { get; set; }
    
        public virtual Product Item { get; set; }
    }
