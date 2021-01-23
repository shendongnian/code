    EmployeeDbdb = new EmployeeDb();
    var empl = new Employee
    {
          FirstName = "Test",
          LastName = "demo",
          Email = "aa@aaa.com"
    };
    var role = new Role
    {
        Name = "Role1"
    };
    db.Roles.AddOrUpdate(role);
    db.Employees.AddOrUpdate(empl);
    db.AssignedRoles.AddOrUpdate(new AssignedRole
    {
          Role = role,
          Employee = empl
    });
    db.SaveChanges();
