    public static class DatabaseUtility
    {
        public static T Read<T>(
            MySqlConnection conn,
            string query,
            Action<MySqlDataReader> callback);
    }
