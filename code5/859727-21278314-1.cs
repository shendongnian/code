    public class GenericController : Controller
    {
    	private IGenericControllerRepository repository;
    
    	public GenericController() : this(new GenericRepository()) { }
    
    	public GenericController(IGenericControllerRepository genericRepository)
    	{
    		this.repository = genericRepository;
    	}
    
    	// GET: /controller
    	public ActionResult Index()
    	{
    		MyModel[] m = repository.ComplexMethod();
    		return View("Index", m);
    	}
    }
