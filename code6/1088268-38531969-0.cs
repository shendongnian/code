		public static IEnumerable<T> ExecuteSProc<T> ( this DbContext ctx , string schema , string sproc , params SqlParameter[] para ) {
			return ctx.Database.SqlQuery<T>( "Execute " + schema + "." + sproc , para ).ToArray();
		}
		public static T ExecuteSProcSingle<T> ( this DbContext ctx , string schema , string sproc , params SqlParameter[] para ) {
			return ctx.Database.SqlQuery<T>( "Execute " + schema + "." + sproc , para ).SingleOrDefault();
		}
		public static int ExecuteSProc ( this DbContext ctx , string schema , string sproc , params SqlParameter[] para ) {
			return ctx.Database.ExecuteSqlCommand( "Execute " + schema + "." + sproc , para );
		}
