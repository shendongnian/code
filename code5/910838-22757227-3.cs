     public class HomeController : Controller
        {
            //
            // GET: /Home/
    
            public ActionResult Index()
            {
                var model = new TestModel();
    
                return View(model);
            }
    }
    
    
        public class TestModel
        {
            [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
            [Display(Name = "Year")]
            public int? Year { get; set; }
        }
    
