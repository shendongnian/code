    IQueryable<Employee> employees = DB.Employees;
    
    if (!string.IsNullOrEmpty(FirstName))
    {
        employees = employees 
            .Where(emp => emp.FirstName.Contains(fName));
    }
    if (!string.IsNullOrEmpty(LastName))
    {
        employees = employees 
            .Where(emp => emp.Last.Contains(lName));
    }
