	var Employees = 
		(from d in context.Employees
		join a in context.Address on d.ID equals a.EmployeeID
		select new //select the important bits we'll need in memory
        {
			Employee = d,
			Address = a,
		})
		.AsEnumerable() //AsEnumerable() it to make it enumerate from the database, now everything you need is in memory
		.Select(x => new Employee
		{
			Id = x.Employee.Id,
			PreferredName = GetPreferredName(x.Employee.FirstName, x.Employee.MiddleName, x.Employee.LastName, x.Employee.Alias),
			StreetAddress = x.Address.StreetAddress 
		})
		.ToList();
