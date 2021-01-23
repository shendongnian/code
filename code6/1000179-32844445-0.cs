    /// <summary>
    /// Recursively gets all the ProjectItem objects in a list of projectitems from a Project
    /// </summary>
    /// <param name="projectItems">The project items.</param>
    /// <returns></returns>
    public IEnumerable<ProjectItem> GetProjectItems(EnvDTE.ProjectItems projectItems)
    {
    	foreach (EnvDTE.ProjectItem item in projectItems)
    	{
    		yield return item;
    
    		if (item.SubProject != null)
    		{
    			foreach (EnvDTE.ProjectItem childItem in GetProjectItems(item.SubProject.ProjectItems))
    				yield return childItem;
    		}
    		else
    		{
    			foreach (EnvDTE.ProjectItem childItem in GetProjectItems(item.ProjectItems))
    				yield return childItem;
    		}
    	}
    
    }
