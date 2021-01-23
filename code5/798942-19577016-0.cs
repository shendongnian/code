    public abstract class BaseController : Controller
    {
        protected readonly MyEntities db;
        public BaseController()
        {
            db = new MyEntities();
        }
    }
