    public ActionResult Create()
    {
           ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
           ViewBag.ProcedureID = new SelectList(db.ProcedureSubCategories, "ID", "Name");
           return View();
    }
