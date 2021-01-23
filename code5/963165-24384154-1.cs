    public class CustomerController : Controller
    {
      private readonly IProductService _productService ;
    
      public CustomerControll(IProductService productService)
      {
        _productService = productService;
      }
    
      public ActionResult Index(int id)
      {
        //call service here
      }
    }
