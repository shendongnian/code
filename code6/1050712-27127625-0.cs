         public EmployeeRepository(DataBaseContext context)
    {
        _context = context;
    }
         public void Create(Employee employee)
    {
        var roles = from r in _context.Roles
            where r.Name == employee.Role.Name
            select r; 
        employee.Role = roles.First();
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }
