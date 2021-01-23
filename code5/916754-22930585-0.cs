	public static T MyDefault<T>()
	{
		var factory = new Dictionary<Type,Func<object>>{
			{typeof(string), ()=> String.Empty },
			{typeof(MyClass), ()=> new MyClass() },
		};
		
		Type t = typeof(T);
		
		if(factory.ContainsKey(t))
			return (T)factory[t]();
		else
			return default(T);
	}
