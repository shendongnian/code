    public class ProductDTO : BaseDTO { 
       public static ProductDTO Empty { get { return new ProductDTO(); } }
    }
    public class Product : BaseObjectWithDTO<ProductDTO,int> { 
       public static IQueryable<Product> QuerySource { get; set; }
    }
