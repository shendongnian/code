    var query = session.Query<Employee>();
    var list = query.Select(s => new Employee
        {
            FirstName = s.FirstName,
            LastName = s.LastName,
            ...
         })
         .ToList();
