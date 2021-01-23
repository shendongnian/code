     for (int i = 1; i < 10; i++)
            {
                var emp = new Employee
                    {
                        EmployeeID = i,
                        EmployeeName = string.Concat("Employee", i),
                        Email = string.Concat("Email", i)
                    };
                employeeCollection.Add(emp);
                SendEMail(emp);
            }
