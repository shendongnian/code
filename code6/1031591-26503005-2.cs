	private static Dictionary<Type, Delegate> map = new Dictionary<Type, Delegate>()
	{
		{ typeof(long), (Func<object, long>)(o => o == null ? -13 : (long)o) },
		{ typeof(float), (Func<object, float>)(o => o == null ? -13.0f : (float)o) },
		{ typeof(double), (Func<object, double>)(o => o == null ? -13.0 : (double)o) },
	};
	
	public static Generic Get<Generic>(this object self)
	{
		return
			map.ContainsKey(typeof(Generic))
				? ((Func<object, Generic>)(map[typeof(Generic)]))(self)
				: (Generic)self;
	}
