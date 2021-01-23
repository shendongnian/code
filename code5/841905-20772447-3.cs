    //My Controller class
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View(new ViewModel());
        }
        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(ViewModel vm)
        {
            try
            {
                var domainModel = new DomainModel();
                domainModel.CreateSomething(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new ViewModel());
            }
        }
        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            ViewModel model = new DomainModel().FindSomething(id);
            return View(model);
        }
     
        [HttpPost]
        public ActionResult Edit(ViewModel editModel)
        {
            try
            {
                var dm = new DomainModel();
                dm.EditSomething(editModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new ViewModel());
            }
        }
     }
