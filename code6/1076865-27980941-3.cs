    var model = new CreateViewModel
                {
                   Producers = new SelectList(db.Procedures, "ProcedureID", "ViCode");
                   Departments = db.Departments.ToList()
                }
    return View(model);
