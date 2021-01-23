    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            
            Person male = new Person() { Name = "Bob Smith", IsActive = true };
            Person female = new Person() { Name = "Generic Jane", IsActive = false };
            Person[] persons = {male, female};
            viewModel.Persons = persons;
            return View(viewModel);
        }
    }
