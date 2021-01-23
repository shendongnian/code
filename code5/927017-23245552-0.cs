    public ActionResult DetailsData(int? k)
        {
            EmployeeContext Ec = new EmployeeContext();
            if (k != null)
            {
               Employee emp = Ec.Employees.Single(X => X.EmpId == k.Value);
               return View(emp);
            }
            return View();
        }
