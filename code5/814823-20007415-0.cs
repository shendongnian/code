	public IQueryable<ProjectSearchResult> GetProjects(Expression<Func<SubProject, bool>> predicate)
	{
		return
			from p in db.Projects
		    select new ProjectSearchResult {
				ProjectId = p.ProjectId,
				NoOfSubProjects = p.SubProjects.Count(predicate),
			};
	}
