	using (var context = new MyContext())
	{
		foreach (var Employee in context.Employees)
		{
			PrintEmployee(Employee);
		}
	}
