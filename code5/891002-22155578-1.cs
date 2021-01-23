    public class ProductRepositoryImplementation : ProductRepository
    {
        private DbSet<Product> _products;
        public IQueryable<Product> Products
        {
            get { return _products; }
        }
        public ProductRepositoryImplementation(DbSet<Product> products)
        {
            _products = products;
        }
        public void Add(Product model)
        {
            _products.Add(model);
        }
        public void Remove(Product model)
        {
            _products.Remove(model);
        }
    }
