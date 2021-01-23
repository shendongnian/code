    public interface IJoinedService : IProductService, IMainService
    {
    }
    
    public class JoinedService : IJoinedService
    {
       private ProductService _productService;
       public void GetProducts()
       {
         _productService.GetProducts();
       }
    }
