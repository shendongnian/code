    private static Dictionary<Type,Func<object>> factory = new Dictionary<Type,Func<object>>{
			{typeof(string), ()=> String.Empty },
			{typeof(MyClass), ()=> new MyClass() },
		};
	public static T MyDefault<T>()
	{
	
		Type t = typeof(T);
		Func<object> func = null;
		if(factory.TryGetValue(t, out func))
		    return (T)func();
        else
            return default(T);
	}
