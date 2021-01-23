    private IEnumerable<MenuItem> GetAllChildrenOfSpecificMenuItemRecursively(MenuItem menuItem)
    {
        var children = new List<MenuItem>();
        foreach (MenuItem mi in menuItem.Children)
        { 
            // Why are you checking this?
            if (mi.ParentMenuItemId != null)
            {
                // Why are you checking this?
                if (mi.ParentMenuItemId == menuItem.MenuItemId)
                {
                    children.Add(mi);
                }
                else
                {
                    
                    children.AddRange(GetAllChildrenOfSpecificMenuItemRecursively(mi))
                }
            }
        }
    
        return Children;
    }
