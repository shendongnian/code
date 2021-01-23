    public class ProductDTO : BaseDTO { 
       public static ProductDTO Identity(ProductDTO dto){ return dto; };
    }
    public class Product : BaseObjectWithDTO<ProductDTO,int> { 
       public static IQueryable<Product> QuerySource { get; set; }
    }
