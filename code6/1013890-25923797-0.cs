    public JsonResult GetRecentEmployeeRecords(string whse)
    {
        var recentRecords = _employeeDb.EmployeeMasters.Where(e => e.Branch == whse).OrderBy(e => e.CreateDate).Take(10);
        var list = recentRecords.Select(r => r.EmployeeNumber + " - " + r.LastName + ", " + r.FirstName).ToList();
    
        return Json(list, JsonRequestBehavior.AllowGet);
    }
