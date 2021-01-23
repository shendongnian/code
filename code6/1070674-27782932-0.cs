    public ActionResult CreateEmployee() 
    {
        using (var db = new DepartmentDbContext())
        {
            var model = new CreateEmployee();
            model.Departments = db.AngTestDepartments.ToList();
            return View(model);
        }
    }
