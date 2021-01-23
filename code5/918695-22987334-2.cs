    public ActionResult Index()
            {
                var model = new GlobalModel():
                var model.IndexModels = GetDetails();
                return View(model); 
            }
