    var query = await
        (from d in context.Employees
        join a in context.Address on d.ID equals a.EmployeeID
        select new 
        {
            Employee = d,
            Address = a,
        })
        .ToListAsync();
    
    var Employees = query    
        .Select(x => new Employee
        {
            Id = x.Employee.Id,
            PreferredName = GetPreferredName(x.Employee.FirstName, x.Employee.MiddleName, x.Employee.LastName, x.Employee.Alias),
            StreetAddress = x.Address.StreetAddress 
        })
        .ToList();
