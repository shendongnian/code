     [HttpPost]
     public ActionResult Add(SampleModel model)
     {
            model.Items.Add(new ItemModel { Name = "New Item" });
            return PartialView("Items");
     }
     public ActionResult Index()
     {
            var model = new SampleModel(); // Or get model
            return View(model);
     }
     [HttpPost]
     public ActionResult Index(SampleModel model)
     {
            // Save model to DB
            return RedirectToAction("Index");
     }
