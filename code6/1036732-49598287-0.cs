    public class MyDbContext : DbContext
    {
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }
        public virtual int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);
        }
