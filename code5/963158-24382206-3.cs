    public class ProductService : IProductRepository
    {
        public IQueryable<Product> GetProductByCustomer(int id)
        {
            // Some logic; Get all the products bought by the customer
        }
    }
