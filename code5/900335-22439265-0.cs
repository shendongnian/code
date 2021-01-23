    public class ProductController : Controller
    {
        private IProductRepository repository;
        //The framework will call this constructor
        public ProductController() : this(new ProductRepository()) { }
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
