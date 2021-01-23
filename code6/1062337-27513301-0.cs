    var query = from e in Employees
                join a in Employees on e.EmployeeAssistantID equals a.EmployeeID
                where e.EmployeeID == 2
                select new
                {
                   EmployeeID = e.EmployeeID,
                   AssistantID = a.EmployeeID,
                   EmployeeProjects = Projects.Where(p => p.EmployeeID == e.EmployeeID),
                   AssistantProjects = Projects.Where(p => p.EmployeeID == a.EmployeeID)
                };
