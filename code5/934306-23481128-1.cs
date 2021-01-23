    [Query(IsComposable=false)]
        public Employee GetEmployeeByID(int? EmployeeID)
        {
            var empData = from Employee in this.Context.Employees
                          where Employee.Id == EmployeeID
                          select new Employee
                          {
                              ID = Employee.Id,
                              FirstName = Employee.FirstName,
                              LastName = Employee.LastName
                          };
            return empData.Single();
        } 
