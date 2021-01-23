    [HttpGet]
    [BreezeQueryable(AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.OrderBy)]
    public IQueryable<Employee> Employees() {
      return ContextProvider.Context.Employees;
    }
