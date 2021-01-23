    public ActionResult InfoFor_PaySlip() 
    {
        YourModel model = new YourModel();
        var dates = (from ps in DataContext.MonthlyRecords select new {ps.Month }).Distinct();
        model.Months = new SelectList(dates, "Month", "Month");
        var names = (from n in DataContext.HrEmployees select new { n.EmplID, n.EmplName }).Distinct();
        model.EmployeeList = new SelectList(names, "EmplID", "EmplName");
        return View(model);
    }
