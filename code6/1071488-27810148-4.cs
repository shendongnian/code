    public class HomeController : Controller
    {
        private IService service = new Service(new SampleContext());
        public HomeController(){}
        // GET: Home
        public ActionResult Index()
        {
            var author = service.Query<Author>().ToList();
            var authors = service.Query<Author>().ToListAsync();
            var authors = service.Query<Author>().Where(a => a.Name != "Orwell").ToList();
            var authors = service.Query<Author>().Where(a => a.Name != "Orwell").ToListAsync();
            var author = service.Query<Author>().FirstOrDefault();
            var author = service.Query<Author>().FirstOrDefaultAsync();
            var author = service.Query<Author>().Where(a => a.Name == "Orwell").FirstOrDefault();
            var author = service.Query<Author>().Where(a => a.Name == "Orwell").FirstOrDefaultAsync();
            var book = service.Query<Book>().Where(b => b.Title == "The Wasp Factory").FirstOrDefault();
            return View(author);
        }
    }
