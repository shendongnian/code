    public class ProductService : IProductRepository
    {
        private readonly IProductRepository _productRepository;
            
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository=productRepository;
        }
        public IQueryable<Product> GetProductByCustomer(int id)
        {
            // Some logic; Get all the products bought by the customer
        }
    }
