    public static Employee EmployeeFactory(IDataRecord record)
    {
        var employee = new Employee
        {
            EmployeeID = (int)record[0],
            EmployeeName = (string)record[1],
            Roles = new List<Role>()
        };
        employee.Roles.Add(new Role{RoleID = (int)record[2], roleName=(string)record[3]});
        return employee;
    }
    IEnumerable<Employee> employees = MyCommonDAL.ExecuteQueryGenericApproach
        <Employee>(commandText, commandParameters, Employee.EmployeeFactory)
            .GroupBy(
                x => new { x.EmployeeID, x.EmployeeName},
                (key, group) => 
                    new Employee
                        {
                            EmployeeId=key.EmployeeID, 
                            EmployeeName=key.EmployeeName,
                            Roles = group.SelectMany(v => v.Roles).ToList()
                        }).ToList();
