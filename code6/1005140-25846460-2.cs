	public static class ObjectHelper
	{
		public static void ExecuteRecursive(object item, Action<object> execute, params Func<object, object>[] childSelectors)
		{
			ExecuteRecursive<object, object>(item, null, (c, i) => execute(i), childSelectors);
		}
		public static void ExecuteRecursive<TObject>(object item, Action<TObject> execute, params Func<object, object>[] childSelectors)
		{
			ExecuteRecursive<object, TObject>(item, null, (c, i) => execute(i), childSelectors);
		}
		public static void ExecuteRecursive<TContext, TObject>(object item, TContext context, Action<TContext, TObject> execute, params Func<object, object>[] childSelectors)
		{
			ExecuteRecursive(item, context, (c, i) =>
			{
				if(i is TObject)
				{
					execute(c, (TObject)i);
				}
			}, childSelectors);
		}
		public static void ExecuteRecursive<TContext>(object item, TContext context, Action<TContext, object> execute, params Func<object, object>[] childSelectors)
		{
			execute(context, item);
			if(item is IEnumerable)
			{
				foreach(var subItem in item as IEnumerable)
				{
					ExecuteRecursive(subItem, context, execute, childSelectors);
				}
			}
			if(childSelectors != null)
			{
				foreach(var subItem in childSelectors.Select(x => x(item)).Where(x => x != null))
				{
					ExecuteRecursive(subItem, context, execute, childSelectors);
				}
			}
		}
	}
