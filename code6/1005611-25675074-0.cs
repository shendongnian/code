    public bool IsNotNullOrEmpty(object obj)
    {
    	var e = obj as System.Collections.IEnumerable;
    	if (e == null || !e.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))) return false;
    
    	return e.GetEnumerator().MoveNext();
    }
