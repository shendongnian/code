    // Add a new Role
    Role role = new Role();
    role.RoleID = 1;   // TODO: make identity in database
    role.RoleName = "Role 1";
    db.Roles.Add(role);
    db.SaveChanges();
    // Add a new Employee
    Employee employee = new Employee();
    employee.EmployeeID = 1;   // TODO: make identity in database
    employee.FirstName = "Carl";
    employee.LastName = "Prothman";
    db.Employee.Add(employee);
    db.SaveChanges();
    // Add a new Project
    Project project = new Project();
    project.ProjectID = 1;   // TODO: make identity in database
    project.ProjectName = "Create new data model";
    db.SaveChanges();
    // Add employee to project as role1
    ProjectEmployee projectEmployee = new ProjectEmployee();
    projectEmployee.ProjectID = project.ProjectID;
    projectEmployee.EmployeeID = employee.EmployeeID;
    projectEmployee.RoleID = role.RoleID;
    db.ProjectEmployees.Add(projectEmployee);
    db.SaveChanges();
