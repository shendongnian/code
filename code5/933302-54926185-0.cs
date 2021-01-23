	public static class DbValueExtensions
	{
		// Used to convert values coming from the db
		public static T As<T>(this object source)
		{
			return source == null || source == DBNull.Value
				? default(T)
				: (T)source;
		}
		// Used to convert values going to the db
		public static object AsDbValue(this object source)
		{
			return source ?? DBNull.Value;
		}
	}
