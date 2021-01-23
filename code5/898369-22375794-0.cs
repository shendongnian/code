    var employees = from emp in dbContext.Employees
                    join task in dbContext.TaskAssignmentTable 
                    on emp.employeeID equals task.FKEmployeeID
                    into tEmpWithTask
                    from tEmp in tEmpWithTask.DefaultIfEmpty()
                    group tEmp by new { emp.EmployeeID, emp.Name } into grp
                    select new {
                      grp.Key.EmployeeID,
                      grp.Key.Name,
                      grp.Count(t=>t.TaskID != null)
                    };  
       
