    public ModuleDTO GetModulesForUser(string userName)
    {
        // Returns the list of IDs
    	var ids = ListOfUserModules(userName);
    	var modules = GetModuleTree(null);
    	var module = modules.First();
    	
    	PruneTree(module, ids);
    
    	return module;
    }
    
    public List<ModuleDTO> GetModuleTree(ModuleDTO parentModule)
    {
    	int? parentID = null;
    
    	if (parentModule != null)
    	{
    		parentID = parentModule.ID;
    	}
    
    	var childModules = _modules.All().Where(s => s.ParentID == parentID).Select(x => x.ToDTO());
    
    	List<ModuleDTO> modules = new List<ModuleDTO>();
    
    	foreach (var m in childModules)
    	{
    		m.ChildModules = GetModuleTree(m);
    		modules.Add(m);
    	}
    
    	return modules;
    }
    
    private void PruneTree(ModuleDTO root, List<int> ids)
    {
    	for(int i = root.ChildModules.Count() - 1; i >= 0; i--)
    	{
    		PruneTree(root.ChildModules[i], ids);
    		if (root.ChildModules[i].ChildModules.Count == 0)
    		{
    			if (!ids.Contains(root.ChildModules[i].ID))
    			{
    				root.ChildModules.RemoveAt(i);
    			}
    		}
    	}
    }
