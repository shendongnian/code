	var Employees = context.Employees.Select(e => 
		select new //select the important bits we'll need in memory
        {
			Employee = e,
			Address = e.Address, //join is done for you!
		})
		.AsEnumerable() //AsEnumerable() it to make it enumerate from the database, now everything you need is in memory
		.Select(x => new Employee
		{
			Id = x.Employee.Id,
			PreferredName = GetPreferredName(x.Employee.FirstName, x.Employee.MiddleName, x.Employee.LastName, x.Employee.Alias),
			StreetAddress = x.Address.StreetAddress 
		})
		.ToList();
