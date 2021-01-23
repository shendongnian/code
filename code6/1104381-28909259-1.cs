    public ActionResult Index()
    {
      MasterVM model = new MasterVM();
      // Set the values of only those models you want to display forms for
      model.Model2 = new Model2();
      return View(model);
    }
    [HttpPost]
    public ActionResult Index(MasterVM model)
    {
      if(!ModelState.IsValid)
      {
        return View();
      }
      if (model.Model1 != null)
      {
        // save Model1
      }
      else if (model.Model2 != null)
      {
        // save Model2
      }
      ....
      // redirect somewhere
    }
