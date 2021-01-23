    var result = db.TBL_Employees
         .Join(db.TBL_Departments, u => u.Department_ID, v => v.Department_ID, 
               (u, v) => new {Employee = u, Department = v})
         .Join(db.TBL_Employees, ed => ed.emp.Manager_ID, x => x.Emp_ID, 
               (ed, x) => new {EmployeeDepartment = ed, Manager = x})
         .Join(db.TBL_Roles, edm => edm.EmployeeDepartment.RoleID, z => z.RoleID, 
               (edm, z) => new {EmployeeDepartmentManager = edm, Role = z})
    .Select(thing => new
    {
       Name = thing.EmployeeDepartmentManager.EmployeeDepartment.Employee.Emp_First_Name,
       Department = thing.EmployeeDepartmentManager.EmployeeDepartment.Department.Department_Name,
       Manager = thing.EmployeeDepartmentManager.Manager.Emp_First_Name,
       Role = thing.Role.RoleName
    });
