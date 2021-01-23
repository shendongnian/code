    bool TryFindGridItem(PropertyGrid grid, string propertyName, out GridItem discover)
    {
    	if (grid is null)
    	{
    		throw new ArgumentNullException(nameof(grid));
    	}
    
    	if (string.IsNullOrEmpty(propertyName))
    	{
    		throw new ArgumentException("You need to provide a property name", nameof(propertyName));
    	}
    
    	discover = null;
    	var root = pgTrainResult.SelectedGridItem;
    	while (root.Parent != null)
    		root = root.Parent;
    
    	foreach (GridItem item in root.GridItems)
    	{
    		//let's not find the category labels 
    		if (item.GridItemType!=GridItemType.Category)
    		{
    			if (match(item, propertyName))
    			{
    				discover= item;
    				return true;
    
    			}
    		}
    		//loop over sub items in case the property is a group
    		
    		foreach (GridItem child in item.GridItems)
    		{
    			if (match(child, propertyName))
    			{
    				discover= child;
    				return true;
    			}
    		}
    		
    
    		//match based on the property name or the DisplayName if set by the user
    		static bool match(GridItem item, string name)
    			=> item.PropertyDescriptor.Name.Equals(name, StringComparison.Ordinal) || item.Label.Equals(name, StringComparison.Ordinal);
    
    
    	}
    	return false;
    }
