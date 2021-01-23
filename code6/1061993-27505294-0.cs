    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Employee Employee) {
     _db.Employees.Add(Employee);
     _db.SaveChanges();
    
     var id = Employee.Id;
     return RedirectToAction("EditEmployeeViewModel", new { id = id});
    }
   
