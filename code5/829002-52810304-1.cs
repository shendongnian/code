        public ActionResult edit(int id)
    {
        Employee emp = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
        ViewBag.DepartmentListItems = db.Departments.Distinct().Select(i => new SelectListItem() { Text = i.DepartmentName, Value = i.DepartmentId.ToString() }).ToList();
        return View(emp);
    }
