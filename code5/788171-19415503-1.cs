    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public ActionResult Index(int page=1)
        {
            var allProducts = _productsRepository.GetAll();
            return View(allProducts)
        }
    }
