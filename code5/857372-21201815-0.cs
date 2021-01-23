    public static class DataExtensions
        {
        public static string GetSafeString(this OleDbDataReader reader, string colName)
        {
            if (reader[colName] != DBNull.Value)
                return reader[colName].ToString();
            else
                return string.Empty;
        }
    }
