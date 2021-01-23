    public static IList<T> SearchGridView<T>(IList<T> list, String term) 
    {
        IList<PropertyInfo> properties = typeof(T).GetProperties();
    	var t = term.ToLower();
        return list
    		.Where(item =>
    			properties
    				.Select(p => p.GetValue(item).ToString())
    				.Any(v => v.Contains(t)))
    		.ToList();
    }
