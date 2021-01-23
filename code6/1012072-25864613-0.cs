    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }
        
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId {get;set;}
    
        public string CategoryName { get; set; }
        public ProductCategory ParentCategory { get; set; }
    }
