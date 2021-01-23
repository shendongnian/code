    public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseEntities, Configuration>());
            using (var entities = new DatabaseEntities())
            {
                entities.Database.Initialize(true);
            }
            Console.Read();
        }
        public class ProgressInterceptor : IDbCommandInterceptor
        {
            private int currentRecord = 0;
            public int TotalCount { get; set; }
            public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
            }
            public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
            }
            public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                Console.WriteLine("Progress {0:P}", ++currentRecord / (double)TotalCount);
            }
            public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
            }
            public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
            }
            public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
            }
        }
    }
