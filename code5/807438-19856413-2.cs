    public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
    {
        if (child == null) return null;
    
        // get parent item
        var parentObject = VisualTreeHelper.GetParent(child);
        // we’ve reached the end of the tree
        if (parentObject == null) return null;
        // check if the parent matches the type we’re looking for
        var parent = parentObject as T;
        // return parent if match or use recursion to proceed with next level
        return parent ?? GetParent<T>(parentObject);            
    }
    
    public static T GetChild<T>(this DependencyObject parent) where T : DependencyObject
    {
        if (parent == null) return null;
        T result = null;
   
        var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (var i = 0; i < childrenCount; i++)
        {
            var childObject = VisualTreeHelper.GetChild(parent, i);
            var child = childObject as T;
            if (child == null)
                result = childObject.GetChild<T>();
            else
            {
                result = (T) childObject;
                break;
            }
        }   
        return result;
    }
