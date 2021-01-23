    [HttpPost]
    
    [ValidateAntiForgeryToken]
    public ActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
    
            int empId = employee.EmployeeID;
            employee.LName = "abc";
            TryValidateModel(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(employee);
    }
