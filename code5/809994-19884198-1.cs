    public class DatabasesController : Controller
    {
        private UnitOfWork _unitOfWork;
        private WebContext _context;
        public DatabasesController()
        {
            _context = new WebContext();
            _unitOfWork = new UnitOfWork(_context);
        }
        //
        // GET: /Databases/
        public ViewResult Index()
        {
            List<Database> databases =
                _unitOfWork
                .Repository<Database>()
                .Query()
                .Include(database => database.FileEntitiesInfo)
                .Get()
                .ToList();
            _unitOfWork.Save();
            return View(databases);
        }
    }
