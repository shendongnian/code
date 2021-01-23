	public static class ObjectExtensions
	{
		public static TResult IfNotNull<TValue, TResult>(this TValue value, Func<TValue, TResult> @delegate)
			where TValue : class
		{
			if (@delegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			return value != null ? @delegate(value) : default(TResult);
		}
	}
