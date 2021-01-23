    public ActionResult GetEmployees()
    {
        var employeeList = new EmployeeListViewModel {
            Emp = new List<Employee>
            {
               new Employee {  EmpName= "ScottGu", EmpPhone = "23232323", EmpNum="242342"},
               new Employee { EmpName = "Scott Hanselman", EmpPhone = "3435353", EmpNum="34535"},
               new Employee { EmpName = "Jon Galloway", EmpPhone = "4534535345345",   
                  EmpNum="345353"}
            }
        };
        return PartialView("_EmpPartial", employeeList );
    }
