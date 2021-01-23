    /// <summary>
    /// Check if the given type is ComVisible
    /// </summary>
    /// <param name="type">the type to check</param>
    /// <returns>whether or not the given type is ComVisible</returns>
    private bool isComVisible(Type type)
    {
    	bool comVisible = true;
    	//first check if the type has ComVisible defined for itself
    	var typeAttributes = type.GetCustomAttributes(typeof(ComVisibleAttribute),false);
    	if 	(typeAttributes.Length > 0)
    	{
    		 comVisible = ((ComVisibleAttribute)typeAttributes[0]).Value;
    	}
    	else
    	{
    		//no specific ComVisible attribute defined, return the default for the assembly
    		var assemblyAttributes = type.Assembly.GetCustomAttributes(typeof(ComVisibleAttribute),false);
    		if 	(assemblyAttributes.Length > 0)
    		{
    			 comVisible = ((ComVisibleAttribute)assemblyAttributes[0]).Value;
    		}
    	}
    	return comVisible;
    }	
