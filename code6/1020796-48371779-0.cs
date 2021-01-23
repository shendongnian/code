	public static class ContextExtensions
	{
		public static void DbccCheckIdent<T>(this DbContext context, int? ressedTo = null) where T : class
		{
			context.Database.ExecuteSqlCommand(
				$"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED{(ressedTo != null ? "," + ressedTo : "")});" +
				$"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED);");
		}
		public static string GetTableName<T>(this DbContext context) where T : class
		{
			var objectContext = ((IObjectContextAdapter) context).ObjectContext;
			return objectContext.GetTableName<T>();
		}
		public static string GetTableName<T>(this ObjectContext context) where T : class
		{
			var sql = context.CreateObjectSet<T>().ToTraceString();
			var regex = new Regex(@"FROM\s+(?<table>.+)\s+AS");
			var match = regex.Match(sql);
			var table = match.Groups["table"].Value;
			return table;
		}
	}
