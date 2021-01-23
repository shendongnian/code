    .Select(e => new destination.Employee {
        Id = e.Id,
        Department = new destination.Department {
            Id = e.Department.Id,
            Name = e.Department.Name
        }
    });
