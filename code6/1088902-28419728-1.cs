    [HttpGet]
    public ActionResult CreateCompany()
    {
        var listData = _appFunctions.GetAllCategory();
        var model = new CompanyProfileModelView
        {
          CategoryList = new SelectList(listData, "CategoryTypeID ", "CategoryTitle")
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult CreateCompany(CompanyProfileModelView model)
    {
      if (!ModelState.IsValid)
      {
        // Re-assign select list if returning the view
        var listData = _appFunctions.GetAllCategory();
        model.CategoryList = new SelectList(listData, "CategoryTypeID ", "CategoryTitle");
        return View(model)
      }
      // Save and redirect
    }
