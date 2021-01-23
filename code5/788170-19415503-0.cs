    public class ProductsRepository : IProductsRepository
    {
         public List<Product> GetAll()
         {
            //EF stuff 
            return _dbcontext.Products;
         }
    } 
    
