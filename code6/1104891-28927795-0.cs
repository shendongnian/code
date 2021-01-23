    public static class DatabaseUtility
    {
        public static Read<T>(
            MySqlConnection conn,
            string query,
            Func<MySqlDataReader, T> callback);
    }
