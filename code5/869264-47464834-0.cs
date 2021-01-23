		public static IQueryable Set(this DbContext context, Type T)
		{
			
			// Get the generic type definition
			MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);
			// Build a method with the specific type argument you're interested in
			method = method.MakeGenericMethod(T);
			
			return method.Invoke(context, null) as IQueryable;
		}
