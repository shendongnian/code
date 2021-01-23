     public ActionResult Index()
     {
         return RedirectToAction("AnotherAction", new
         {
             Parameter1 = Parameter1,
             Parameter2 = Parameter2,
          });
     }
        
     [HttpGet]
     public ActionResult AnotherAction(ModelClass model)
     {
         //model.Parameter1
         //model.Parameter2
         return View(model);
     }
