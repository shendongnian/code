    public class PeopleController: Controller
    {
        private readonly IPeopleRepository repository;
        public PeopleController(IPeopleRepository repository)
        {
            this.repository = repository;
        }
    
        public ActionResult Index()
        {
            var people = this.repository.Get().ToList();
            // Depending on the requirements of your view you might have
            // other method calls here and collect a couple of your domain models
            // that will get mapped and aggregated into a single view model
            // that will be passed to your view
            return View(people);
        }
    
        ...
    }
