    public IEnumerable<Employee> Search(SearchCriteria searchCriteria)
    {
      var employees = _dbContext.Employees.Where(e => e.Age == searchCriteria.Age);
      if(searchCriteria...)
      {
        employees = employees.Where(e => ...);
      }
      return employees;
    }
