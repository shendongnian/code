    public class MyController : Controller
    {
        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
        public ActionResult MyAction() 
        {
             Logger.Info("New Request Created.");
        }
    }
