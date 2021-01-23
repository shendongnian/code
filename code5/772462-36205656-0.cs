    organisations = organisations.OrderBy(org =>
    {
       org.Departmets = org.Departments
       .OrderBy(dept =>
       {
         dept.Employees = dept.Employees
                         .OrderBy(employee => employee.Code)
                         .ThenBy(employee=>employee.Name);
         return dept.Code;
       })
       .ThenBy(dept=>dept.Name);
       return org.Code;
    })
    .ThenBy(org=>org.Name); 
