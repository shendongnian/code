	public static void Bar<T>(dynamic obj)
	{
		bool IsTypeRight = 
            (typeof(Obj1) == typeof(T) || typeof(Obj2) == typeof(T));
		bool IsObjRight = obj is T;
		if (!IsTypeRight || !IsObjRight)
		{
			var message = 
				string.Format("Expecting type of <{0}>.", typeof(T).Name);
			throw new System.ArgumentException(message);
		}
		// ...
	}
