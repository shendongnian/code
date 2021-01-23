    public static class Helper
    {
        public static T GetSafe<T>(this SqlDataReader reader, string name)
        {
            var value = reader[name];
            return value == DBNull.Value ? default(T) : (T) value;
        }
    }
