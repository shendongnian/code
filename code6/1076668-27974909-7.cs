    public class UnitOfWork 
    {
        private YourContext Context { get; set; }
        public List<T> SQLQuery<T>(string sql, params object[] parameters)
        {
           return Context.Database.SqlQuery<T>(sql, parameters).ToList();
        }
    }
