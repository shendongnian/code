    public class MyController : Controller
    { 
        private readonly IDataGetter _dataGetter;
        public MyController(IDataGetter dataGetter)
        {
            _dataGetter = dataGetter;
        }
        public ActionResult Index()
        {
            MyViewModel model = new MyViewModel();
            myList = _dataGetter.GetAllData(User.IDentity.Name); // Fill your list with 2k rows
            model.List = myList;
            return View(model);
        }
    }
