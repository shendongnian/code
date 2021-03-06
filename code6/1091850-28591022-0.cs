    void Main()
	{
		var computeCount = 0;
		var item1 = GetCached(new{x = 1, y = 2}, (arg)=>{computeCount++; return arg.x + arg.y;});
		Console.WriteLine(item1);
		var item2 = GetCached(new{x = 1, y = 2}, (arg)=>{computeCount++; return arg.x + arg.y;});
		Console.WriteLine(item2);
		var item3 = GetCached(new{x = 1, y = 3}, (arg)=>{computeCount++; return arg.x + arg.y;});
		Console.WriteLine(item3);
		Console.WriteLine("Compute count:");
		Console.WriteLine(computeCount);
	}
	Dictionary<object, object> _cache = new Dictionary<object, object>();
	E GetCached<T,E>(T arg, Func<T,E> getter)
	{
		// var cacheKey = arg.ToString();
		
		object result;
		
		if (!_cache.TryGetValue((object)arg, out result))
		{
			var newItem = getter(arg);
			_cache.Add(arg, newItem);
			return newItem;
		}
		else
		{
			Console.WriteLine("Cache hit: {0}", arg);
		}
		
		return (E)result;
	}
