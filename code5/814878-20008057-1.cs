    var subDepartment = new Department
                         {
                             DepartmentName = "D1"
                         };
    var department = new Department
                         {
                              DepartmentName = "D1"
                         };
    department.Departments.Add(subDepartment);
    
    context.SaveChanges();
