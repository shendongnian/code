	public Empoyee FindEmployeeByName(string name)
	{
		using (var context = new MyContext())
		{
			return context.Employees.FirstOrDefault(e => e.Name == name);
		}
	}
