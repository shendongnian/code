    var query1 = from emp in employees
                                 group emp.Email by new { emp.EmpId, emp.Type } into empgroup
                                 select new
                                 {
                                     UserId = empgroup.Key.EmpId,
                                     EmployeeType = empgroup.Key.Type,
                                     EmaiIds = empgroup.SelectMany(x => x)
                                 };
        
        
                    foreach (var x in query1)
                    {
                        Console.WriteLine(x.UserId);
                        Console.WriteLine(x.EmployeeType);
                        foreach (var emails in x.EmaiIds)
                        {
                            Console.WriteLine(emails);
                        }
                    }
