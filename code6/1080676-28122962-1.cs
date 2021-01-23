    public ActionResult Edit(int ID)
    {
      MyModel model = new MyModel();
      model.SelectedOrganisation = someValue; // set if appropriate
      model.SelectedEmployee = someValue; // set if appropriate
      ConfigureEditModel(model); // populate select lists
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(MyModel model)
    {
      if(!ModelState.IsValid)
      {
        ConfigureEditModel(model); // reassign select lists
        return View(model);
      }
      // save and redirect
    }
    
    private void ConfigureEditModel(MyModel model)
    {
      // populate select lists
      model.OrganisationList = new SelectList(db.Organisations, "ID", "Name");
      if(model.SelectedOrganisation.HasValue)
      {
        var employees = db.Employees.Where(e => e.Organisation == model.SelectedOrganisation.Value);
        model.EmployeeList = new SelectList(employees, "ID", 
      }
      else
      {
        model.EmployeeList = new SelectList(Enumerable.Empty<SelectListItem>());
      }
    }
    [HttpGet]
    public JsonResult FetchEmployees(int ID)
    {
      var employees = db.Employees.Where(e => e.Organisation == ID).Select(e => new
      {
        ID = e.ID,
        Name = e.Name
      });
      return Json(data, JsonRequestBehavior.AllowGet);
    }
