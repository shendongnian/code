    public IEnumerable<SuperEmployee> GetSuperEmployees(int page)
    {
        using (var context = new NORTHWNDEntities()) 
        {    
            var q = context.SuperEmployeeSet.OrderBy(emp=>emp.EmployeeID).Skip(page * PageSize).Take(PageSize);    
            return q.ToList(); 
       }
    }
