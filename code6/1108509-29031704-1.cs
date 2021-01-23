    public ActionResult Details(int id = 0)
    {
      ViewModel model = new ViewModel();
      model.Departments = db.Departments.ToList();
      model.Teachers = db.Teachers.Where(m => m.DepartmentID ==  id).ToList();
      return View(model);
    }
