    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> GetCurrentProductsOnOrderForCustomer(int customerId)
        {
            // etc.
        }
    }
