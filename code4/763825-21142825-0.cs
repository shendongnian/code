	static Func<T, object> BuildGrouper<T>(IEnumerable<string> properties) {
		var arg = Expression.Parameter(typeof(T), helper.getName());
        // This is the list of property accesses we will be using
		var parameters = properties.Select(propName => Expression.Property(arg, propName)).ToList();
        // Find the correct overload of Tuple.Create.
        // This will throw if the number of parameters is more than 8!
		var method = typeof(Tuple).GetMethods().Where(m => m.Name == "Create" && m.GetParameters().Length == parameters.Count).Single();
        // But it is a generic method, we need to specify the types of each of the arguments
		var paramTypes = parameters.Select(p => p.Type).ToArray();
		method = method.MakeGenericMethod(paramTypes);
        // Invoke the Tuple.Create method and return the Func
		var call = Expression.Call(null, method, parameters);
		var lambda = Expression.Lambda<Func<T, object>>(call, arg);
		return lambda.Compile();
	}
