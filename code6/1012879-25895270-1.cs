    using (var db = new AppContext())
    {
        // User can have optional Employee.
        db.Users.Add(new User { UserID = 1, Employee = null });
        db.SaveChanges();
    }
    using (var db = new AppContext())
    {
        // Employee can have optional User.
        db.Employees.Add(new Employee { EmployeeID = 1, User = null });
        db.Employees.Add(new Employee { EmployeeID = 2, User = null });
        db.SaveChanges();
    }
     User            Employee
    ------     ----------------------
    UserID     EmployeeID User_UserID
      1            1         null
                   2         null
