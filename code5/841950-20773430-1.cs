    [HttpPost]
    public ActionResult Create(Employee employeeform)
    {
        if (ModelState.IsValid)
        {
            ...
            Employee employee = new Employee();
            employee.DepartmentID = employeeform.DepartmentId;
            ...
       
        }
            return View();
     }
