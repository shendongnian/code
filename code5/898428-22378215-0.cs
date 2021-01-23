    List<Employee> employee = new List<Employee>() 
    { 
        new Employee() { id = 1, Name = "Samar" }, 
        new Employee() { id = 1, Name = "Samar" },
        new Employee() { id = 1, Name = "Samar" },
        new Employee() { id = 2, Name = "Sid" }
    };
    List<TaskAssignment> taskAssignment = new List<TaskAssignment>() 
    { 
        new TaskAssignment(){FKEmployeeID = 1},
        new TaskAssignment(){FKEmployeeID = 1}
    };
    var cls = from e in employee
                join emp in taskAssignment on e.id equals emp.FKEmployeeID into empout
                group e by new { e.id, e.Name } into g
                select new { g.Key.id, g.Key.Name, CNT = g.Count() };
