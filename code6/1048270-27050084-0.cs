    public static IEnumerable<T> FindDescendants<T>(this DependencyObject parent) where T : DependencyObject 
    {
        return FindDescendants<T>(parent, null, false);
    }
    public static IEnumerable<T> FindDescendants<T>(this DependencyObject parent, Func<T, bool> predicate) where T : DependencyObject 
    {
        return FindDescendants(parent, predicate, false);
    }
    public static IEnumerable<T> FindDescendants<T>(this DependencyObject parent, bool deepSearch) where T : DependencyObject 
    {
        return FindDescendants<T>(parent, null, deepSearch);
    }
    public static IEnumerable<T> FindDescendants<T>(this DependencyObject parent, Func<T, bool> predicate, bool deepSearch) where T : DependencyObject 
    {
        var children = LogicalTreeHelper.GetChildren(parent).OfType<DependencyObject>().ToList();
        foreach (var child in children) 
        {
            var typedChild = child as T;
            if (typedChild != null && (predicate == null || predicate.Invoke(typedChild))) 
            {
                yield return typedChild;
	            if (deepSearch) 
                {
                    foreach (var foundDescendant in FindDescendants(child, predicate, true)) yield return foundDescendant;
                }
            } 
            else 
            {
                foreach (var foundDescendant in FindDescendants(child, predicate, deepSearch)) yield return foundDescendant;
            }
        }
    }
