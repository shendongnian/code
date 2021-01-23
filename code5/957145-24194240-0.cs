    using LinqKit;
    results = db.Employers.AsExpandable()
                          .OrderBy(e => e.Name)
                          .Select(DataMappers.EmployerMapper)
                          .ToList();
