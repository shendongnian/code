    public static class DbHelper
    {
        public static T GetValue<T>(this SqlDataReader sqlDataReader, string columnName)
        {
            var value = sqlDataReader[columnName];
            return value == DBNull.Value ? default(T) : (T) value;
        }
    }
