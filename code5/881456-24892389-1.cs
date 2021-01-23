     public class EnumController : Controller
        {
            // GET: Enum
            public ActionResult Index()
            {
                var model = new Test {MyCars = Test.Cars.Car3}; // set default value
                return View(model);
            }
            [HttpPost]
            public ActionResult Index(Test model)
            {
                .....
            }
        }
