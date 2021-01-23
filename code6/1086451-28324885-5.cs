    public class ProductsController : ApiController
    {
        public IEnumerable<Product> GetAllProductsForCategory(string categoryId)
        {
            return products.Where(p => p.Category == categoryId);
        }
    }
