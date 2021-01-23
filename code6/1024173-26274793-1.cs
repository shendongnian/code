    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set;}
        public int CurrentProductDetailId { get; set; }
        [ForeignKey("CurrentProductDetailId")]
        public virtual ProductDetail CurrentProductDetail { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
    public class ProductDetail
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public int ProductId { get; set; }
       [ForeignKey("ProductId")]
       public virtual Product Product { get; set; } 
    }
