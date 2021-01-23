    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ParentModel model = new ParentModel();
                model.Name = "Parent model";
                model.ChildModel = new ChildModel();
                model.ChildModel.Name = "Child Name";
    
                return View(model);
            }
            public ActionResult SearchMethod (ParentModel model)
            {
                var name = model.Name;
                var childName = model.ChildModel.Name;
                return View(model);
            }
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
    
                return View();
            }
     }
