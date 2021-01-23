	public static Array CreateAndFillArray(Type type, int length)
	{
		var result = Array.CreateInstance(type, length);
		for (int ixItem = 0; ixItem < result.Length; ixItem++)
			result.SetValue(Activator.CreateInstance(type), ixItem);
		return result;
	}
	public static T[] CreateAndFillArray<T>(int length)
	{
		var type = typeof(T);
		var result = new T[length];
		for (int ixItem = 0; ixItem < result.Length; ixItem++)
			result[ixItem] = (T)Activator.CreateInstance(type);
		return result;
	}
	public static T[] CreateAndFillArray<T>(int length)
		where T : new()
	{
		var result = new T[length];
		for (int ixItem = 0; ixItem < result.Length; ixItem++)
			result[ixItem] = new T();
		return result;
	}
