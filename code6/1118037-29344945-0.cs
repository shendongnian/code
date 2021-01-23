    var result = employees.SelectMany(x => x.WorkDays, (employeeObj, workDays) => 
                                                       new { employeeObj, workDays })
                          .GroupBy(x => x.workDays.Date)
                          .Select(x => new
                                 {
                                    Date = x.Key,
                                    NameAndHours = x.Select(z => 
                                        new { 
                                                Name = z.employeeObj.Name, 
                                                Hours = z.workDays.Hours 
                                            })
                                 }).ToList();
