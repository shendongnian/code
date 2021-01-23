    void Main()
    {
    	var c = new C();
    	Set(new MyType(), c);
    	Set(new MyOtherType(), c);
    }
    
    void Set<T>(T item, C c)
    {
    	var field = typeof(C).GetFields().SingleOrDefault(x => x.FieldType.GetInterface(typeof(IList).FullName) != null &&
    														   x.FieldType.GetGenericArguments().All(ft => ft == typeof(T)));
    	((IList)field.GetValue(c)).Add(item);
    }
