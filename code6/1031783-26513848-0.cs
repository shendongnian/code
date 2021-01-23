    var predicate = PredicateBuilder.True<Entities.ProjectSearchResult>(); // Expression with your type
    if (!String.IsNullOrWhiteSpace(projectName))
        predicate = predicate.And(p => p.ProjectName.Contains(projectName));    
    ...
    using (CHIPSDbContext db = new CHIPSDbContext())
    {
        var query = (from p in db.Projects
                     join s in db.ProjectStatus on p.ProjectStatusCode equals s.ProjectStatusCode
                     join b in db.ProjectBrands on p.ProjectId equals b.ProjectId into brandList
                     from sublist in brandList.DefaultIfEmpty()
            select new Entities.ProjectSearchResult
            {
                ProjectID = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectLaunchName = p.ProjectLaunchName,
                Status = s.ProjectStatusDesc,
            })
             .Where(predicate.Expand()) // Don't forget to expand predicate
             .AsExpandable()
             .ToList();
        return query;
     }
