    public bool IsNullOrEmpty(object obj)
    {
    	var e = obj as System.Collections.IEnumerable;
    	if (e == null || !e.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))) return false;
    
    	var it = e.GetEnumerator();
    	using(it as IDisposable)
    	{
    		return it.MoveNext();
    	}
    }
