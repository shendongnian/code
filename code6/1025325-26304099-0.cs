     public class Product
        {
        public string Id {get;set;}
        public Name {get;set;}
        public string Category {get;set;}
        public decimal Price {get;set;}
        }
        
    public AppContext : DbContext
    {
    public DbSet<Product> Products {get;set;}
    }
    
    
        public class IProductRepository
        {
            public IQuerable<Product> Products{get;}
        }
        
        public class ProductRepository : IProductRepository
        {
         private  AppContext context = new DBContext();
        
        public IQuerable<Product> Products
        {
            get
        {
        context.Products;
        }
        }
        
        }
        
        
        
        Now in your Web Api method & controller.... 
        
        
        public class ProductController 
        {
        private IProductRepository repo;
        
            public ProductController()
        {
             repo = new ProductRepository(); // or use DI
        }
        
        public List<Product> Get()
        {
         return repo.Products.ToList();
        }
        
        }
