    void Main()
    {
    	var a = typeof(TextWriter).IsLeafType(); //false
    	var b = typeof(StreamWriter).IsLeafType(); //true
    }
    
    static class Ex
    {
    	private static Lazy<ISet<Type>> typeSetLazy =
    		new Lazy<ISet<Type>>(() => {
    			var types = AppDomain
    						.CurrentDomain
    						.GetAssemblies()
    						.SelectMany(a => a.GetTypes()
    						                  .Where(t=>t.IsClass));
    			var typesAndBaseTypes = types
    									.Select(t => new { Type = t, t.BaseType })
    									.ToList();
    			var typesWithSubclasses = typesAndBaseTypes
    										.Join(
    											typesAndBaseTypes,
    											t => t.Type,
    											t => t.BaseType,
    											(t1, t2) => t2.BaseType);
    			var typesHs = new HashSet<Type>(types);
    			typesHs.ExceptWith(typesWithSubclasses);
    			return typesHs;
    		});
    	public static bool IsLeafType(this Type type)
    	{
    		return typeSetLazy.Value.Contains(type);
    	}
    }
