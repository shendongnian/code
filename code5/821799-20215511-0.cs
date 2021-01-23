    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }
