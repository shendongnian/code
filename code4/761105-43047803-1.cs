    public static class DbHelper
    {
        public static T GetValue<T>(this SqlDataReader sqlDataReader, string columnName)
        {
            var value = sqlDataReader[columnName];
            if (value != DBNull.Value)
            {
                return (T)value;
            }
            return default(T);
        }
    }
