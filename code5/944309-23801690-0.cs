	var map = emp.ToDictionary(e => e.Empid);
	
	Func<int?, string> getEmployeeName = i =>
		i == null ? "n/a" : map[i].EmpName;
	
	var query =
		from e in emp
		select new
		{
			e.EmpName,
			ManagerName = getEmployeeName(e.Managerid)
		};
