    IEnumerable<Employee> employees = MyCommonDAL.ExecuteQueryGenericApproach
            <Employee>(commandText, commandParameters, Employee.EmployeeFactory);
    employees = employees.GroupBy(
                    x => new
                        {
                            x.EmployeeID, 
                            x.EmployeeName
                        },
                    (key, groupedEmployees) => 
                        new Employee
                            {
                                EmployeeId=key.EmployeeID, 
                                EmployeeName=key.EmployeeName,
                                Roles = groupedEmployees.SelectMany(v => v.Roles)
                            });
    return employees.ToList();
