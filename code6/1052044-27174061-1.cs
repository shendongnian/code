    class DummyInterceptor : DbCommandInterceptor
	{
		public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			base.ReaderExecuting(command, interceptionContext);
			Debug.WriteLine(new string('=', 70));
			Debug.WriteLine(command.CommandText);
		}
	}
