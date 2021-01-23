    public class UnitOfWork 
    {
        private YourContext Context { get; set; }
        public DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters)
        {
           return Context.Database.SqlQuery<T>(sql, parameters);
        }
    }
