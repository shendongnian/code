    public class HomeController : Controller
    {
        private IRepository repo = new Repository(new SampleContext());
        public HomeController(){}
        // GET: Home
        public ActionResult Index()
        {
            var author = repo.Query<Author>().ToList();
            var authors = repo.Query<Author>().ToListAsync();
            var authors = repo.Query<Author>().Where(a => a.Name != "Orwell").ToList();
            var authors = repo.Query<Author>().Where(a => a.Name != "Orwell").ToListAsync();
            var author = repo.Query<Author>().FirstOrDefault();
            var author = repo.Query<Author>().FirstOrDefaultAsync();
            var author = repo.Query<Author>().Where(a => a.Name == "Orwell").FirstOrDefault();
            var author = repo.Query<Author>().Where(a => a.Name == "Orwell").FirstOrDefaultAsync();
            var book = repo.Query<Book>().Where(b => b.Title == "The Wasp Factory").FirstOrDefault();
            return View(author);
        }
    }
