    namespace WebAPI.Model
    {
       public class ProductsModel
    { 
            [Table("products")]
            public class Products
            {
                [Key]
                public int slno { get; set; }
               
                public int productId { get; set; }
                public string ProductName { get; set; }
               
                public int Price { get; set; }
    }
            }
        }
