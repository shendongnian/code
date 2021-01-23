    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            switch (employee.DepartmentName)
	        {
	            case "IT":
                    employee.StatusID = 1
                    break;
	            case "HR":
                    employee.StatusID = 2
                    break;
	            default:
                    employee.StatusID = 1
                    break;
	        }
            db.Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employee);
    }
