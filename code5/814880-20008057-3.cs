    var subDepartment = new Department
                         {
                             DepartmentName = "D1"
                         };
    var department = new Department
                         {
                              DepartmentName = "D1"
                         };
    department.Department = subDepartment;
    context.Departments.Add(department);
    
    context.SaveChanges();
