    //this is testable just inject a mock of IProductDAO during unit testing
    public class ProductService : IProductService
    {
        private IProductDAO _productDAO;
    
        public ProductService(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }
    
        public List<Product> GetAllProducts()
        {
            return _productDAO.GetAll();
        }
        ...
    }
