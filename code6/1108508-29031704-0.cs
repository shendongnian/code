    public ActionResult Details(int id = 0)
    {
      ViewModel model = new ViewModel();
      model.Departments = db.Departments.ToList();
      model.Teachers = db.Teachers.Where(m => m.DepartmentID ==  m.DepartmentID).ToList();
      return View(model);
    }
