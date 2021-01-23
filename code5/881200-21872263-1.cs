    public EmployeeProcessOutput RetrieveEmployee(EmployeeProcessInput input)
    {     
          var employee = input.Employee;
          if (input.EmployeeId == null)
              CreateEmployee(ref employee);
          return new EmployeeProcessOutput
                {
                    Employee = employee,
                    State = "Stored" 
                };
    }
    private void CreateEmployee(ref Employee employee)
    {
          //Call a service to create an employee in the system using the employee 
          //info such as name, address etc and will generate an id and other 
          //employee info.
          var output = Service(employee)
          employee = output.Employee;
     }
