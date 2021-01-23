    public class TheController : Controller
    {
        private IAlmostConcreteRepository repo;
        public TheController (IAlmostConcreteRepository r)
        {
            repo = r;
        }
    }
