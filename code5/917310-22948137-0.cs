    public void Query(string name)
    {
    	Expression<Func<Project, bool>> filter = PredicateBuilder.True<Project>();
    	
    	filter = filter.And(p => !p.IsDeleted);
    	
    	if (!string.IsNullOrEmpty(name)
    		filter = filter.And(p => p.Name == name);
    	
    	IEnumerable<Project> list = session.Query<Project>()
    										.Where(filter)
    										.FetchMany(r => r.UnfilteredProjectApplications)
    										.ThenFetch(r => r.Application)
    										.ToList();
    }
