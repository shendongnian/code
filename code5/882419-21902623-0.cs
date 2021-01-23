    public class MyCommandInterceptor : IDbCommandInterceptor
    {
        public void ReaderExecuting(DbCommand command,
                    DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            command.CommandText = command.CommandText.Replace("a", "b");
        }
        
        public void NonQueryExecuting(DbCommand command, 
                    DbCommandInterceptionContext<int> interceptionContext)
        { }
        
        ... lots of stubs
    }
