        List<Employee> employees = new List<Employee>() 
        {
            new Employee() { EmpID = 1 , Name ="AC", DateofPresentation=new DateTime(2013,12,24)},
            new Employee() { EmpID = 1 , Name ="AC", DateofPresentation=new DateTime(2013,12,23)},
            new Employee() { EmpID = 1 , Name ="AC", DateofPresentation=new DateTime(2013,12,22)},
            new Employee() { EmpID = 1 , Name ="AC", DateofPresentation=new DateTime(2013,12,21)},
            new Employee() { EmpID = 2 , Name ="AC", DateofPresentation=new DateTime(2013,12,25)},
            new Employee() { EmpID = 2 , Name ="AC", DateofPresentation=new DateTime(2013,12,21)}
        };
        var list = employees.
            Select(i => new Employee()
            {
                EmpID = i.EmpID,
                Name = i.Name,
                DateofPresentation = i.DateofPresentation,
                Employees = employees.Where(j => i.EmpID == j.EmpID && j.DateofPresentation < i.DateofPresentation).ToList()
            }).
                GroupBy(x => x.EmpID).
                Select(g => g.OrderByDescending(i => i.DateofPresentation).First()).
                ToList();
