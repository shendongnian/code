    namespace SQLite
    {
        public partial class SQLiteAsyncConnection
        {
            public void ResetConnections()
            {
                SQLiteConnectionPool.Shared.Reset();
            }
        }
    }
