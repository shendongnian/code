        namespace DropDown.Controllers
      {
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.InterviewList = NumberList;
            return View(new BindDropDown());
        }
        [HttpPost]
        public ActionResult Index(BindDropDown d)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
            }
            else
            {
                ViewBag.Message = "error";
            }
            ViewBag.NumberList = NumberList;
            return View(new BindDropDown());
        }
        public ActionResult About()
        {
            return View();
        }
        public static IEnumerable<SelectListItem> NumberList
        {
            get
            {
                IEnumerable<NumberClass> interviewAppeals = Enum.GetValues(typeof(NumberClass))
                                                      .Cast<NumberClass>();
                return from item in interviewAppeals
                       select new SelectListItem
                       {
                           Text = item.ToString(),
                           Value = ((int)item).ToString()
                       };
            }
        }
    }
    public enum NumberClass
    {
        One = 1,
        Two = 2,
        Three = 3
    }
     }
 
 
