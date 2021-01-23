    public IEnumerable<Employee> GetByEmployeIdAndJobId(int empId, int jobId)
    {
        var predicate = PredicateBuilder.True<Employee>();
        if(empId > 0)
            predicate = predicate.And(e => e.EmployeeId == empId);
        if(jobId > 0)
            predicate = predicate.And(e => e.JobId == jobId);
        return Table.Employees.Where(predicate).ToList();
    }    
