    var allClasses = GetProjectItems(Context.ActiveProject.ProjectItems).Where(v => v.Name.Contains(".cs"));
    // check for .cs extension on each
    
    foreach (var c in allClasses)
    {
    	var eles = c.FileCodeModel;
    	if (eles == null)
    		continue;
    	foreach (var ele in eles.CodeElements)
    	{
    		if (ele is EnvDTE.CodeNamespace)
    		{
    			var ns = ele as EnvDTE.CodeNamespace;
    			// run through classes
    			foreach (var property in ns.Members)
    			{
    				var member = property as CodeType;
    				if (member == null)
    					continue;
    
    				foreach (var d in member.Bases)
    				{
    					var dClass = d as CodeClass;
    					if (dClass == null)
    						continue;
    
    					var name = member.Name;
    					if (dClass.Name == "DataMigrationImpl")
    					{
    						yield return new Migration(member);
    					}
    				}
    			}
    		}
    	}
    }
