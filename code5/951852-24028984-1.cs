    EmployeeFunctionInProject efpAlias = null;
    Employee empAlias = null;
    Project projectAlias = null;
    // subquery, selecting two pair table and the Project table
    var subquery = QueryOver.Of<EmployeeFunctionInProject>(() => efpAlias)
        .JoinAlias(() => efpAlias.Entity, () => projectAlias)
        // just the ProjectNumber over 2
        .Where(() => projectAlias.ProjectNumber > 2)
        // the ID of an employee
        .Select(x => efpAlias.Employee.Id);
    // the root query, over Employee
    var list = session.QueryOver<Employee>(() => empAlias)
        .WithSubquery
           .WhereProperty(() => empAlias.Id)
           .In(subquery)
        // the rest of the query
        ...// Take(), Skipe(), Select(), List()
