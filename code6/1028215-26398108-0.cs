    public class TheController : Controller
    {
        private MyConcreteRepository repo;
        public TheController (MyConcreteRepository r)
        {
            repo = r;
        }
    }
