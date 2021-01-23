    public class UnitOfWork 
    {
        private YourContext Context { get; set; }
        public List<T> SQLQuery<T>(string sql, params Object[] parameters)
        {
           return Context.Database.SqlQuery<T>(sql, parameters).ToList();
        }
    }
