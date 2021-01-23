    public static class SQLiteConnectionExtensions
    {
        public static int DropTable(this SQLiteConnection conn, string tableName)
        {
            var query = string.Format("drop table if exists \"{0}\"", tableName);
            return conn.Execute(query);
        }
    }
