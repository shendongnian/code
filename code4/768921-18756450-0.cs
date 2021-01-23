    public ActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            employee.Manager = db.Employees.Find(employee.Manager.Id) // load Manager properties
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employee);
    }
