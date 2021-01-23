    public class Product
    {
      //...additional properties...
      public virtual ICollection<ProductCategoryXref> AssociatedCategories {get; set;}
    }
    
    public class Category
    {
      //...additional properties...
      public virtual ICollection<ProductCategoryXref> AssociatedProducts {get; set;}
    }
    
    public class ProductCategoryXref
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SortOrder { get; set; }
        // Additional Columns...
     
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
