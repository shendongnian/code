    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            if(employee.DepartmentName == "IT")
            {
               employee.StatusID == 1;
            }
            else if(employee.DepartmentName == "HR")
            {
               employee.StatusID == 2;
            }
            else
            {
               employee.StatusID == 1;
            }
            db.Employee.Add(employee);
            db.SaveChanges();            
            return RedirectToAction("Index");
        }
        return View(employee);
    }
