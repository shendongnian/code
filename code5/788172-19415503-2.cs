    public class FakeProductsRepository : IProductsRepository
    {
         public List<Product> GetAll()
         {
            return new List<Product> 
               { 
                  new Product { Name = "PASTE" }
                  new Product { Name = "BRUSH" } 
               }, 
         }
    } 
