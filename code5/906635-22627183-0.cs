	public List<EmpBO> ReadData()
	{
		return File
			.ReadAllLines("emp.txt")
			.Select(data =>
			{
				var tokens = data.Split(';');
				return new EmpBO()
				{
					Id = int.Parse(tokens[0]),
					Name = tokens[1],
					Salary = double.Parse(tokens[2]),
					Br = double.Parse(tokens[3]),
					Tax = double.Parse(tokens[4]),
					Designation = tokens[5],
				};
			})
			.ToList();
	}
