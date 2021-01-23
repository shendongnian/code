    private readonly ProductManufacturer _productManufacturer = new  ProductManufacturer();
    private readonly IList<ProductCategory> _productCategories = new List<ProductCategory>();
    public ProductManufacturer ProductManufacturer
    {
        get { return _productManufacturer; }
    }
   
    public IEnumerable<ProductCategory> ProductCategory
    {
        get { return _productCategories; }
    }
