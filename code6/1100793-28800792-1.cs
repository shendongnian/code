    public ActionResult Apply(int ID)
    {
      CareersClasses model = new CareersClasses();
      model.JobID = ID;
      return View(model);
    }
    [HttpPost]
    public ActionResult Apply(CareersClasses model, HttpPostedFileBase file)
    {
      // save the model and redirect
    }
