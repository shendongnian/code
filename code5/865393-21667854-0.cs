    public class MyController : Controller
    {
        public static List<MyObject> myList = null;
        static MyController()
        {
            myList = GetAllData(User.IDentity.Name); // Fill my list with 2k rows
        }
        public ActionResult Index()
        {
            MyViewModel model = new MyViewModel();
            model.List = myList;
            return View(model);
        }
        public JsonResult GetData(int i)
        {
            return Json(myList.Where(x => x.Data == i));
        }
    }
