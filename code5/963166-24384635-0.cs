    ProductRepository : IProductRepository 
    {
        public IEnumerable<Product> FindAll()
        {
            ....
        }
    }
    ProductService
    {
        public void ProductService(IProductRepository productRepository)
        {
              _repository = productRepository;
        }
        //Business rules follows
    }
