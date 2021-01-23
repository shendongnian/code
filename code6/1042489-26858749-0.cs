    [HttpGet]
    public ActionResult CreateEmployeeBasicDetails(EmployeeSuperClass employeeSuperClass)
    {
        employeeSuperClass.mainTbl = new EmployeeMainTable();
        employeeSuperClass.mainTbl.employee_DepartmentTable = dt.GetDepartments();
    }
