    let departmentResult = 
    // Where clause goes here
    .Select(department => 
	{
	   var x = new Department()
		{
			Name = department["Name"].ToString(),
			Employees = department.Employees
		}
		
	   x.Employees.AddRange(employeesResult);
	   return x;
	}).FirstOrDefault()
