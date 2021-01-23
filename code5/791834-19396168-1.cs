    var ResultQuery = dtTasks.AsEnumerable()
                      .Select(Task => {
                                  try {  
                                      return new { EmployeeName = Task.Field<string>("EmpName").Split(':')[1],
                                               EmployeeCode = Task.Field<string>("EmpName").Split(':')[0],
                                               ProjectId = Task.Field<string>("ProjectName").Split(':')[0],
                                               ProjectName = Task.Field<string>("ProjectName").Split(':')[1],
                                               TaskName = Task.Field<string>("TaskName"),
                                               TaskDescription = Task.Field<string>("TaskDescription"),
                                               StartDate = Task.Field<DateTime>("StartDate"),
                                               Duration = Task.Field<double>("Duration"),
                                               EndDate = Task.Field<DateTime>("EndDate"),
                                               LeadName = Task.Field<string>("LeadBy").Split(':')[1],
                                               LeadId = Task.Field<string>("LeadBy").Split(':')[0]
                                      }
                                   } catch(Exception e) {
                                            Console.WriteLine("Print your warning!");
                                            return null;
                                   }
                      });
 
    foreach (var task in ResultQuery)
    {
       if(task != null) {
            // do your processing
       }
    }
