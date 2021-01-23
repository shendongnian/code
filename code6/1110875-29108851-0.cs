    public static IEnumerable<ProjectAssignment> GetProjectAssignments(int projectId, bool includeAlternates)
    {
        using (ISession session = DataContext.GetSession())
        {
    	    var query = session.QueryOver<ProjectAssignment>()
    	                   .Where(p => p.ProjectId == projectId);
    
    	    if (!includeAlternates) 
    	    {
                query.And(p => !p.IsAlternate);
    	    }
    
            List<ProjectAssignment> results = query.List().ToList();
            return results;
        }
    }
