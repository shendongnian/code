    public ActionResult Edit()
    {
      List<ContactVM> model = new List<ContactVM>();
      // add any existing contacts to edit
      return View(model);
    }
