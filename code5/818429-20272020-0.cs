    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Static.Number = 0;
            return View();
        }
        public JsonResult JsonData()
        {
            if (Static.Number == 0) Static.RunNumber();
            return Json(Static.Number, JsonRequestBehavior.AllowGet);
        }
    }
    public static class Static
    {
        public static int Number { get; set; }
        public static void RunNumber()
        {
            for (int i = 0; i < 250; i++)
            {
                Number = i;
                Thread.Sleep(1000);
            }
        }
    }
