    interface IDatabase
    {
        public IEnumerable<T> SqlQuery<T>(string sql, params Object[] parameters);
    }
    class DatabaseWrapper : IDatabase
    {
        private readonly Database database;
        public DatabaseWrapper(Database database)
        {
            this.database = database;
        }
        
        public IEnumerable<T> SqlQuery<T>(string sql, params Object[] parameters)
        {
            return database.SqlQuery<T>(storedProc, paramList);
        }
    }
