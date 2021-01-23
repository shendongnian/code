    var massagedEmployees = employees.GroupBy(e => e.Department)
                                     .Select(g=> 
                                       new {
                                          Department = g.Key,
                                          SalaryAvg = g.Average(x=>x.Salary)
                                      });
