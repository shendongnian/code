    public class HomeController : Controller
    {
        private void EnsureAge()
        {
            List<string> AgeList = new List<string>();
            AgeList.Add("0-17");
            AgeList.Add("18-21");
            AgeList.Add("22-25");
            AgeList.Add("26-35");
            AgeList.Add("36+");
            ViewData["Age"] = new SelectList(AgeList);
        }
        public ActionResult Index()
        {   
            EnsureAge();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string FirstName, string LastName)
        {
            EnsureAge();
            ViewData["FirstName"] = FirstName;
            return View();
        }
    }
