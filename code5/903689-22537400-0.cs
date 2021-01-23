    public ActionResult MiEmployeeDetails()
    {
      var model = new EmployeeDetailsModel();
      model.Employees = _db.geo_employees.ToList().Select(x => new SelectListItem
       {
          Value = x.name,
          Text = x.name
       }).ToList();
    
       return View(model);
    }
