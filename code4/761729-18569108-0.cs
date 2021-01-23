    public abstract class BaseController : Controller
    {
        public ILog Log
        {
            get { return LogManager.GetLogger(GetType()); }
        }
    }
