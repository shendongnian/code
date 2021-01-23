    public partial class MyDatabaseContext : DbContext
    {
        /// <summary>
        /// Allows you to override queries that use the Database property
        /// </summary>
        public virtual List<T> SqlQueryVirtual<T>(string query)
        {
            return this.Database.SqlQuery<T>(query).ToList();
        }
    }
