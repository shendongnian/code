    var distincts = employees.GroupBy(x => new { x.Name, x.EmployeeNumber } )
        .Select(x => new Employee  
        {
             Name = x.Key.Name,
             EmployeeNumber = x.Key.EmployeeNumber,
             LaborTypeName = x.First().LaborTypeName,
             SysId = x.First().SysId
        })
        .ToList();
