    db.Employee.AddRange(
       nameList.Select(name =>
          new Employee
          {
               Name = name,
               IsDeleted = false
          })
       );
