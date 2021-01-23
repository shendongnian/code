    public class ProductRepository : IProductRepository
    {
        public IQueryable<Product> GetProductByCustomer(int customerId)
        {
            // Some logic; Get all the products bought by the customer
        }
    }
