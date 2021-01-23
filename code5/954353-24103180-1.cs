    public EmployeeResponse GetEmployee(EmployeeRequest request)
    {
        int empId = request.EmployeeRequestID;
        switch (empId)
        {
            case 0:
                return new EmployeeResponse
                {
                   Employee = new FullTimeEmployee()
                  {
                    EmployeeId=1,
                    Name="Chiranjib Nandy",
                    Gender="Male",
                    EmpType=EmployeeType.FullTimeEmployee,
                    AnnualSalary=1500
                  }
                 }
            case 1:
                return new EmployeeResponse
                {
                   Employee = new PartTimeEmployee()
                   {
                      EmployeeId = 1,
                      Name = "Archana Nandy",
                      Gender = "Female",
                      EmpType = EmployeeType.PartTimeEmployee,
                      HoursWorked=9,
                      SalaryPerHour=150
                  }
                }
            default: return null;
    }
 
