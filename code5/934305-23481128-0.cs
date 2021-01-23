     public ActionResult Details(int id)
        {
            WCF_RIA_Project.WCF_RIA_Service wcfria = new WCF_RIA_Project.WCF_RIA_Service();
            WCF_RIA_Project.Employee employee = wcfria.GetEmployeeByID(id);
            ViewData["EmployeeID"] = id;
            ViewData["EmployeeFirstName"] = employee.FirstName;
            ViewData["EmployeeLastName"] = employee.LastName;
            return View();
        }
